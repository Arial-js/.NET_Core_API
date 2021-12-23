using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WebAPI.Model;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost, Route("login")]
        public IActionResult Login([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("Invalid request");
            }

            if (user.Username == "Andrea" && user.Password == "ciao")
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("M=}YcMjHMJUk=KiL{cxX)Bq(ZZ4Xc*&=}$a]mNQxfqb283);pwbc?(4jLfAudL{F3Z5G(;w_D7D*bm/83}&U,?EZ_;ehd/qw[T9HCCa-Q@GiwD94StiVw4QMQnh(9nbS"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var tokeOptions = new JwtSecurityToken(
                    issuer: "http://localhost:44356",
                    audience: "http://localhost:44356",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: signinCredentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return Ok(new { Token = tokenString });
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
