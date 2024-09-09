
using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CatstgramApp.Controllers
{
    [Authorize]
    public class FollowController : BaseController
    {
        private readonly ICurrentUserService currentUserService;
        private readonly IFollowService followService;
        public FollowController(ICurrentUserService currentUserService, IFollowService followService)
        {
            this.currentUserService = currentUserService;
            this.followService = followService;
        }
        [HttpPost("Follow")]
        public ActionResult<Result> Follow(string followerId)
        {
            var followeeId = currentUserService.GetId();
            var result= followService.FollowUser(followeeId,followerId);
            if (result.Successeeded) 
                return Ok("You Follow this user Successfully");
            
            return BadRequest(result.Error);
        }

    }/*353a0ce4-d1dc-4c7a-b3d2-7e05f1eba512*/
}
