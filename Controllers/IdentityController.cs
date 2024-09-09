

using AutoMapper;
using CatstgramApp.Dtos;
using Core.Entities.Identity;
using Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CatstgramApp.Controllers
{

    public class IdentityController : BaseController
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly IMapper mapper;
        private readonly ITokenService tokenService;
       
        public IdentityController(IMapper mapper, UserManager<AppUser>userManager,SignInManager<AppUser>signInManager, ITokenService tokenService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.tokenService = tokenService;
            this.mapper = mapper;

        }
        [HttpPost("Register")]
        public async Task<IActionResult>  Register(RegisterDto registerDto)
        {
           
                var user= mapper.Map<AppUser>(registerDto);
                var result = await userManager.CreateAsync(user, registerDto.Password);
                if(result.Succeeded)
                {
                return Ok(new
                {
                    Email = user.Email,
                    Name = user.UserName,
                    Token = tokenService.CreateToken(user)

                });
                }
                else
                {
                    return BadRequest(result.Errors);
                }
            
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var user=await userManager.FindByEmailAsync(loginDto.Email);
            if (user is not null)
            {
                var result = await signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
                if (result.Succeeded)
                {
                    return Ok(new
                    {
                        Name = user.UserName,
                        Email = user.Email,
                        Token = tokenService.CreateToken(user)

                    });
                }
              
            }
            return Unauthorized();

        }
    }
}
