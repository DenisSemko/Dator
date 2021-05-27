using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Dator.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Dator.Repository.Abstract;

namespace Dator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        public UsersController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            return Ok(await userRepository.GetUsersAsync());
        }

        [HttpGet("{username}")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<ActionResult<User>> GetByUsername(string username)
        {
            return await userRepository.GetUserByUsernameAsync(username);
        }
    }
}
