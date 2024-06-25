using Authentication.API.Data;
using Authentication.API.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Models.DTOs;
using System.Security.Claims;

namespace Authentication.API.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IMapper mapper;
        private readonly ITokenService tokenService;

        public AuthService(
            UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IMapper mapper, ITokenService tokenService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.mapper = mapper;
            this.tokenService = tokenService;
        }

        public async Task<bool> CreateUserAsync(RegisterRequest createUserDto)
        {
            var user = new ApplicationUser
            {
                UserName = createUserDto.Email,
                Email = createUserDto.Email,
            };
            var result = await userManager.CreateAsync(user, createUserDto.Password);
            if (result.Succeeded)
            {
                var roles = createUserDto.Roles ?? new List<string>();
                roles.Add("Reader");

                result = await userManager.AddToRolesAsync(user, roles);
            }
            return result.Succeeded;
        }

        public async Task<IActionResult> DeleteUserAsync(ClaimsPrincipal user)
        {
            var id = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            if (id != null)
            {
                var userToDelete = await userManager.FindByIdAsync(id);
                if (userToDelete != null)
                {
                    await userManager.DeleteAsync(userToDelete);
                    return new OkObjectResult("User was deleted successfully");
                }
            }
            return new NotFoundObjectResult("User not found");

        }

        public async Task<IActionResult> GetUserAsync(ClaimsPrincipal user)
        {
            var id = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            if (id is null)
            {
                return new NotFoundObjectResult("User not found");

            }
            var existingUser = await userManager.FindByIdAsync(id);
            if (existingUser == null)
            {
                return new NotFoundObjectResult("User not found");
            }
            var userDetails = new User
            {
                Id = existingUser.Id,
                Username = existingUser.UserName,
                Email = existingUser.Email
            };
            return new OkObjectResult(userDetails);

        }

        //public async Task<List<UserDto>> GetAllUsersAsync()
        //{
        //    var users = userManager.Users.ToList();
        //    return mapper.Map<List<UserDto>>(users);
        //}

        public async Task<LoginResponse> LoginAsync(LoginRequest loginRequestDto)
        {
            var user = await userManager.FindByEmailAsync(loginRequestDto.Email);
            if (user != null)
            {
                var signInResult = await signInManager.PasswordSignInAsync(user, loginRequestDto.Password, isPersistent: false, lockoutOnFailure: false);


                if (signInResult.Succeeded)
                {
                    var roles = await userManager.GetRolesAsync(user);
                    var token = await tokenService.GenerateJwtTokenAsync(user.Email, roles);


                    return new LoginResponse
                    {
                        JwtToken = token,
                        //User = mapper.Map<UserDto>(user),

                    };

                }
            }

            return null;

        }

        public async Task<IActionResult> LogOutAsync()
        {
            await signInManager.SignOutAsync();
            return new OkObjectResult("User was logged out successfully");
        }

        //public async Task<IActionResult> UpdateAsync(UpdateUserDto updateUserDto, ClaimsPrincipal user)
        //{
        //    var id = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        //    if (id is null)
        //    {
        //        return new NotFoundObjectResult("User not found");

        //    }
        //    var existingUser = await userManager.FindByIdAsync(id);
        //    if (existingUser == null)
        //    {
        //        return new NotFoundObjectResult("User not found");
        //    }
        //    existingUser.UserName = updateUserDto.Username;

        //    var result = await userManager.UpdateAsync(existingUser);
        //    if (result.Succeeded)
        //    {
        //        return new OkObjectResult("User updated successfully");
        //    }
        //    else
        //    {

        //        return new BadRequestObjectResult("Failed to update user");
        //    }

        //}
    }
}
