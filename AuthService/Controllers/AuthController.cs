using AuthService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService service) : ControllerBase
    {


        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var data = await service.GetUserByEmail(request.Email);

            if (data == null)
            {
                return NotFound( new { Message = "User not found" });
            }

            if (data.Password == request.Password)
            {
                var token = GenerateToken(request.Email);
                return Ok(new { Token = token });
            }
            return Unauthorized();
        }

        private string GenerateToken(string username)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("7e4cc73792371b5d166137da2cfcd63321fbb55b91d9e6eafb9a13b0550084ef"));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "rohan_app",
                audience: "rohan_app",
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
            );


            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var result = await service.RegisterUser(request.Email, request.Password);
            if (result)
            {
                return Ok(new { Message = "User registered successfully" });
            }
            return BadRequest(new { Message = "User already exists" });

        }
    }
}
