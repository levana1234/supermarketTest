using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TestTest.Dto;
using TestTest.Entity;
using TestTest.Repozitory;

namespace TestTest.Controllers
{
    public class AuthorizationController : ControllerBase
    {
        public readonly IauthRepozitorycs _iauthRepozitorycs;
        public readonly IConfiguration _configuration;

        public AuthorizationController(IauthRepozitorycs iauthRepozitorycs, IConfiguration configuration ) 
        {
            _iauthRepozitorycs = iauthRepozitorycs;
            _configuration = configuration;
        }

        [HttpPost("register")]

        public async Task<IActionResult> Register(UserRegisterDto userRegisterDto)
        {
            userRegisterDto.UserName = userRegisterDto.UserName.ToLower();

            if(await _iauthRepozitorycs.UserExits(userRegisterDto.UserName))
            {
                return BadRequest("vis hackav bicho");
            }
            Personal personal = new()
            {
                Name = userRegisterDto.UserName,
                Age = userRegisterDto.Age

            };

            User user = new()
            {
                UserName = userRegisterDto.UserName,
                Email = userRegisterDto.Email,
                Personal = personal

            };

            var registration = await  _iauthRepozitorycs.Register(user, userRegisterDto.Password);

            return Ok();

        }

        [HttpPost("login")]

        public async Task<IActionResult> Login (UserLoginDto userLoginDto)
        {
            var userRepo = await _iauthRepozitorycs.Login(userLoginDto.UserName.ToLower()
                , userLoginDto.Password);

            if (userRepo == null)
            {
                return Unauthorized();
            }

            var cleims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userRepo.Id.ToString()),
                new Claim(ClaimTypes.Name, userRepo.UserName)
            };
            
            
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);


            var tokenDescryptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(cleims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds



            };

            var tokenheandler = new JwtSecurityTokenHandler();

            var token = tokenheandler.CreateToken(tokenDescryptor);

            return Ok
                
                ( new
                {
                    token = tokenheandler.WriteToken(token),
                    userRepo
                }
                

                );

        }

        [HttpPut("change-pasword")]

        public async Task<IActionResult> CHangePassword(changepasswordDto changepasswordDto)
        {
            var userRepo = await _iauthRepozitorycs.ChangePassword(changepasswordDto.UserName.ToLower()
               , changepasswordDto.Password, changepasswordDto.NewUserName, changepasswordDto.NewPasword);

            return Ok();
        }
    }
}
