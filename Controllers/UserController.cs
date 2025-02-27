using GameportApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace GamePortApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController() : ControllerBase
    {
        [HttpGet("users")]
        public IActionResult GetUsers(User getUsers)
        {
            return Ok("User list");
        }

    }
}