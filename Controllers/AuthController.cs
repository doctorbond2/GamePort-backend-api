using Microsoft.AspNetCore.Mvc;
using GamePortApi.Services;
using GamePortApi.Models;

namespace GamePortApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(AuthService authService) : ControllerBase
    {
        private readonly AuthService _authService = authService;

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest loginRequest)
        {
            if (loginRequest == null || string.IsNullOrEmpty(loginRequest.Username) || string.IsNullOrEmpty(loginRequest.Password))
            {
                return BadRequest(new { Message = "Invalid login request." });
            }

            bool isAuthenticated = _authService.LoginAsync(loginRequest).Result;

            if (isAuthenticated)
            {
                return Ok(new { Message = "Login successful!" });
            }

            return Unauthorized(new { Message = "Invalid credentials." });
        }
    }
}
