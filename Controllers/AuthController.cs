using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationAuthorizationApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            // Implement login logic here
            return Ok(new { Token = "GeneratedJWTToken" });
        }

        [Authorize(Policy = "AdminPolicy")]
        [HttpGet("admin")]
        public IActionResult AdminEndpoint()
        {
            return Ok("This is an Admin endpoint.");
        }

        [Authorize(Policy = "UserPolicy")]
        [HttpGet("user")]
        public IActionResult UserEndpoint()
        {
            return Ok("This is a User endpoint.");
        }
    }

    public class LoginRequest
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}