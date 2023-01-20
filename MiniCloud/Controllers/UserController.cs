using Application.Interfaces;
using Domain;
using Microsoft.AspNetCore.Mvc;
using MiniCloud.Helpers;
using MiniCloud.Models;
using System.Security.Claims;

namespace MiniCloud.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserModel userModel)
        {
            var response = await _userService.Register(userModel);

            if (response == null)
            {
                return BadRequest(new { message = "Didn't register!" });
            }

            return Ok(response);
        }


        //[HttpGet("auth")]
        //public async Task<IActionResult> Auth()
        //{
        //    var id = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
        //    if(id == null)
        //    {
        //        return StatusCode(401);
        //    }
        //    var userId = id;
        //    var response = await _userService.Auth(Guid.Parse(userId));

        //    if (response == null)
        //    {
        //        return BadRequest(new { message = "Didn't auth" });
        //    }

        //    return Ok(response);
        //}


        [HttpGet]
        [Authorize]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }
    }
}
