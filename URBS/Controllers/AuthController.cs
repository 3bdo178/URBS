using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using URBS.Dtos;
using URBS.Models;
using URBS.Unit_O__Work;

namespace URBS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;

        public AuthController(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.configuration = configuration;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            if(dto==null || !ModelState.IsValid)
            {
                return BadRequest();
            }
            var existinguser = await unitOfWork.Users.GetByEmail(dto.Email);
            if (existinguser != null)
            {
                return Conflict();
            }
            var user = mapper.Map<User>(dto);
            await unitOfWork.Users.Add(user);
            await unitOfWork.Save();
            return Created();
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            if(dto==null || !ModelState.IsValid)
            {
                return BadRequest();
            }
            var exisitinguser = await unitOfWork.Users.GetByEmail(dto.Email);
            if(exisitinguser == null)
            {
                return NotFound();
            }
            if(dto.Password != exisitinguser.Password)
            {
                return Unauthorized();
            }
            var token = CreateToken(exisitinguser);
            return Ok(token);
        }
        private string CreateToken(User user)
        {
            var Jwt = configuration.GetSection("JWT");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Jwt["Key"]));
            var Claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Name, user.FullName),
                new Claim(ClaimTypes.Role, user.Role)
            };
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var tokenobj = new JwtSecurityToken
                (
                issuer: Jwt["Issuer"],
                claims: Claims,
                signingCredentials: signingCredentials,
                audience: Jwt["Audience"],
                expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(Jwt["ExpireMinutes"]))
                );
            var token = new JwtSecurityTokenHandler().WriteToken(tokenobj);
            return token; 
        }

       
    }
}
