using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GamePortApi.Services;
using GamePortApi.Models;
using Microsoft.AspNetCore.Cors;

namespace GamePortApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(AuthService authService, ILogger<AuthController> logger) : ControllerBase
    {
        private readonly AuthService _authService = authService;
        private readonly ILogger<AuthController> _logger = logger;

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            _logger.LogInformation("Login request received: {Username}", loginRequest.Username);
            if (loginRequest == null || string.IsNullOrEmpty(loginRequest.Username) || string.IsNullOrEmpty(loginRequest.Password))
            {
                return BadRequest(new { Message = "Invalid login request." });
            }

            bool isAuthenticated = await _authService.LoginAsync(loginRequest);

            if (isAuthenticated)
            {
                return Ok(new { Message = "Login successful!" });
            }

            return Unauthorized(new { Message = "Invalid credentials." });
        }
    }
}
