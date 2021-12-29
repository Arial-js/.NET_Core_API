using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WebAPI.Model;
using WebAPI.Repository;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public AuthController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost, Route("login")]
        public IActionResult Login([FromBody] User user)
        {
            try
            {
                if (user == null)
                {
                    return BadRequest("Invalid request");
                }
                var userFound = _userRepository.GetByEmail(user.Email);
                if (user.Password == userFound.Result.Password)
                {
                    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("M=}YcMjHMJUk=KiL{cxX)Bq(ZZ4Xc*&=}$a]mNQxfqb283);pwbc?(4jLfAudL{F3Z5G(;w_D7D*bm/83}&U,?EZ_;ehd/qw[T9HCCa-Q@GiwD94StiVw4QMQnh(9nbS"));
                    var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                    var authClaims = new List<Claim> 
                    {
                        new Claim(ClaimTypes.Name, user.Email),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    };

                    var tokenOptions = new JwtSecurityToken(
                        issuer: "http://localhost:44356",
                        audience: "http://localhost:44356",
                        claims: authClaims,
                        expires: DateTime.Now.AddMinutes(30),
                        signingCredentials: signinCredentials
                    );

                    var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                    return Ok(new { Token = tokenString });
                }
                else
                {
                    return Unauthorized();
                }
            } catch(AggregateException ex)
            {
                return NotFound("User not found");
            }
            catch(Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
