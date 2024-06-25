using Authentication.API.Filters;
using Authentication.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Models.DTOs;

namespace Authentication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IAuthService authService;

        public UserController(IAuthService authService)
        {
            this.authService = authService;
        }

        [HttpPost]
        [Route("register")]
        [ValidateModel]

        public async Task<IActionResult> Register([FromBody] RegisterRequest createUserDto)
        {
            var user = await authService.CreateUserAsync(createUserDto);
            if (user != false)
            {
                return Ok("User registred successfuly");
            }
            return BadRequest("Something went wrong");
        }

        [HttpPost]
        [Route("login")]

        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequestDto)
        {
            var loginResponse = await authService.LoginAsync(loginRequestDto);
            if (loginResponse == null || string.IsNullOrEmpty(loginResponse.JwtToken))
            {
                return BadRequest("Your password or username is incorrect");

            }

            return Ok(loginResponse);

        }

        [HttpGet]
        [Authorize(Roles = "Writer,Reader")]
        [Route("user")]

        public async Task<IActionResult> GetUser()
        {
            var result = await authService.GetUserAsync(User);
            return result;
        }

        //[HttpGet]
        //[Authorize(Roles = "Writer")]
        //[Route("users")]

        //public async Task<IActionResult> GetUsers()
        //{
        //    var result = await authService.GetUserAsync(User);
        //    return result;
        //}

        [HttpGet]
        [Authorize(Roles = "Writer,Reader")]
        [Route("logout")]

        public async Task<IActionResult> LogOut()
        {
            await authService.LogOutAsync();
            return Ok("User was logged out successfuly");
        }
        [HttpPut]
        [Authorize(Roles = "Writer,Reader")]
        [Route("updateuser")]

        //public async Task<IActionResult> UpdateUser([FromBody] UpdateUserDto updateUserDto)
        //{
        //    var result = await authService.UpdateAsync(updateUserDto, User);
        //    return result;
        //}

        [HttpDelete]
        [Authorize(Roles = "Writer,Reader")]
        [Route("deleteuser")]

        public async Task<IActionResult> DeleteUser()
        {
            var result = await authService.DeleteUserAsync(User);
            return result;
        }
    }
}
