using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using T2207A_API.Entities;
using T2207A_API.Models.User;
using T2207A_API.DTOs;
using BCrypt.Net;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace T2207A_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly T2207aApiContext _context;
        private readonly IConfiguration _config;

        public AuthController(T2207aApiContext context, IConfiguration configuration)
        {
            _context = context;
            _config = configuration;
        }

        private string GenJWT(User user)
        {
            var secretKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_config["JWT:Key"]));
            var signatureKey = new SigningCredentials(secretKey,
                                    SecurityAlgorithms.HmacSha256);
            var payload = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Email,user.Address),
                new Claim(ClaimTypes.Name,user.Fullname),
                new Claim(ClaimTypes.Role,"Admin")
            };
            var token = new JwtSecurityToken(
                    _config["JWT:Issuer"],
                    _config["JWT:Audience"],
                    payload,
                    expires: DateTime.Now.AddMinutes(60),
                    signingCredentials: signatureKey
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register(UserRegister model)
        {
            try
            {
                var salt = BCrypt.Net.BCrypt.GenerateSalt(10);

                var hassPassword = BCrypt.Net.BCrypt.HashPassword(model.password, salt);

                var user = new User
                {
                    Address = model.email,
                    Fullname = model.fullname,
                    Password = hassPassword,
                };
                _context.Users.Add(user);
                _context.SaveChanges();
                return Ok(new UserDTO
                {
                    id = user.Id,
                    email = user.Address,
                    fullname = user.Fullname,
                    token = GenJWT(user)
                });
            }
            catch (Exception ex)
            {
                return Unauthorized();
            }
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(UserLogin model)
        {
            try
            {
                var user = _context.Users.Where(u => u.Address.Equals(model.email)).First();
                if (user == null)
                {
                    throw new Exception("email or pass is not corect");
                }
                bool verified = BCrypt.Net.BCrypt.Verify(model.password, user.Password);
                if (!verified)
                {
                    throw new Exception("email or pass is not corect");
                }

                return Ok(new UserDTO
                {
                    id = user.Id,
                    email = user.Address,
                    fullname = user.Fullname,
                    token=GenJWT(user)
                });

            } catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("profile")]

        public IActionResult Profile()
        {// get info form token
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if (!identity.IsAuthenticated)
            {
                return Unauthorized("Not Authorized");
            }

            try
            {
                var userClaims = identity.Claims;
                var userId = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

                var user = _context.Users.Find(Convert.ToInt32(userId));
                return Ok(new UserDTO // đúng ra phải là UserProfileDTO
                {
                    id = user.Id, 
                    email = user.Fullname,
                    fullname = user.Fullname,
                });
            } 
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }

            return Ok();
        }
    }
}
