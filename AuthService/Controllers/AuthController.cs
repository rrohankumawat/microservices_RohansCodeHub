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
    public class AuthController : ControllerBase
    {


        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            // For demonstration, we are using hardcoded credentials. In a real application, you should validate against a database.
            if (request.Email == "rohankumawat@gmail.com" && request.Password == "rohan123")
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
    }
}
