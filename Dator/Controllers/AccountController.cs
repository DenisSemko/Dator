using Dator.Models;
using Dator.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ApplicationContext applicationContext;
        private readonly ITokenService tokenService;
        public AccountController(ApplicationContext applicationContext, ITokenService tokenService)
        {
            this.applicationContext = applicationContext;
            this.tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterModel registerModel)
        {
            if (await UserExists(registerModel.Username)) return BadRequest("Username is taken");

            var user = new User
            {
                UserName = registerModel.Username,
                PasswordHash = registerModel.PasswordHash
            };

            applicationContext.Add(user);
            await applicationContext.SaveChangesAsync();
            return new UserDto
            {
                Username = user.UserName,
                Token = tokenService.CreateToken(user)
            };

        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginModel loginModel)
        {
            var user = await applicationContext.Users
                .SingleOrDefaultAsync(x => x.UserName == loginModel.Username.ToLower());

            if (user == null) return Unauthorized("Invalid username");

            return new UserDto
            {
                Username = user.UserName,
                Token = tokenService.CreateToken(user)
            };
        }

        private async Task<bool> UserExists(string username)
        {
            return await applicationContext.Users.AnyAsync(x => x.UserName == username.ToLower());
       }
    }
}

