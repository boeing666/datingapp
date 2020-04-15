using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Dating.App.Backend.Interfaces.Repository;
using Dating.App.Backend.Models;
using Dating.App.Backend.Models.RequestModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Dating.App.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        private readonly IConfiguration _config;
        public AuthController(IAuthRepository repo, IConfiguration config)
        {
            _repo = repo;
            _config = config;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterModel model)
        {
            //validate request later
            model.Username = model.Username.ToLower();
            if (await _repo.UserExists(model.Username))
                return BadRequest("Username already exists");
            var userToCreate = new User
            {
                Username = model.Username
            };
            var createdUser = await _repo.Register(userToCreate, model.Password);

            return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginModel user)
        {
            var userFromRepo = await _repo.Login(user.Username.ToLower(), user.Password);

            if (userFromRepo == null)
                return Unauthorized();

            var result = GenerateToken(userFromRepo);
            
            return Ok(new
            {
                token = result
            });
        }

        private string GenerateToken(User model)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, model.Id.ToString()),
                new Claim(ClaimTypes.Name, model.Username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            var result = tokenHandler.WriteToken(token);

            return result;
        }
    }
}
