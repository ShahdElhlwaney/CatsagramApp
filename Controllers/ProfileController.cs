using AutoMapper;
using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Xml;

namespace CatstgramApp.Controllers
{

    public class ProfileController : BaseController
    {
        private readonly IProfileService profileService;
        private readonly ICurrentUserService currentUserService;

        public ProfileController(IProfileService profileService,ICurrentUserService currentUserService)
        {
            this.profileService = profileService;
            this.currentUserService = currentUserService;
        }
        [Authorize]
        [HttpGet("Mine")]
        public ActionResult<ProfileResponseServiceModel> Mine()
        {
            var userId = currentUserService.GetId();
            var profile=  profileService.ByUser(userId);
       
            return Ok(profile);
        }
        [Authorize]
        [HttpPut("ChangeBiography")]
        public ActionResult<Result> ChangeBiography(string biography)
        {
            var userId = currentUserService.GetId();
            var result = profileService.UpdateBiography(userId, biography);
            if(result.Successeeded)
              return Ok("You Change Biography Successfully");
            return BadRequest();
        }
        [Authorize]
        [HttpPut("ChangeEmail")]
        public ActionResult<Result> ChangeEmail(string email)
        {
            var userId = currentUserService.GetId();
            var result = profileService.UpdateEmail(userId, email);
            if (result.Successeeded)
                return Ok("You Change Email Successfully");
            return BadRequest(result.Error);
        }

        [Authorize]
        [HttpPut("ChangePhoto")]
        public ActionResult<Result> ChangePhoto(string photoUrl)
        {
            var userId = currentUserService.GetId();
            var result = profileService.UpdatePhoto(userId, photoUrl);
            if (result.Successeeded)
                return Ok("You Change Photo Successfully");
            return BadRequest(result.Error);
        }
        [Authorize]
        [HttpPut("ChangeUserName")]
        public ActionResult<Result> ChangeUserName(string userName)
        {
            var userId = currentUserService.GetId();
            var result = profileService.UpdateUserName(userId, userName);
            if (result.Successeeded)
                return Ok("You Change Your Name Successfully");
            return BadRequest(result.Error);
        }
        [Authorize]
        [HttpPut("ChangePrivacy")]
        public ActionResult<Result> ChangePrivacy(bool isPrivate)
        {
            var userId = currentUserService.GetId();
            var result = profileService.UpdatePrivacy(userId, isPrivate);
            if (result.Successeeded)
                return Ok("You Change Your Profile Status Successfully");
            return BadRequest(result.Error);
        }
    }
}

