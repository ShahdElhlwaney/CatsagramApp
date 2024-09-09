using AutoMapper;
using CatstgramApp.Dtos;
using CatstgramApp.Models;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CatstgramApp.Controllers
{
    public class CatsController : BaseController
    {
        private readonly ICatService catService;
        private readonly ICurrentUserService currentUser;
        private readonly IMapper mapper;

        public CatsController(IMapper mapper, ICatService catService,ICurrentUserService currentUser)
        {
            this.mapper = mapper;
            this.catService = catService;
            this.currentUser = currentUser;
        }
        [Authorize]
        [HttpPost("Create")]
        public ActionResult<int> Create(CatDto catDto)
        {
            var cat = mapper.Map<Cat>(catDto);
            var userId = currentUser.GetId();
            var catId = catService.Create(cat, userId);

            return Created("Cat is Created Successfully", catId);
        }
        [Authorize]
        [HttpGet("Mine")]
        public ActionResult<IReadOnlyList<CatListingResponseModel>> Mine()
        {
            var userId = currentUser.GetId();
            var cats = catService.ByUser(userId);
            return Ok(mapper.Map<IReadOnlyList<CatListingResponseModel>>(cats));

        }
        [Authorize]
        [HttpGet("Details{id}")]
        public async Task<ActionResult<CatDetailsResponseModel>> Details(int id)
        {   
            var cat= await catService.Details(id);
            return Ok(mapper.Map<CatDetailsResponseModel>(cat));
        }
        [Authorize]
        [HttpPut("Update")]
        public async Task<ActionResult> Update(CatUpdateDto updateDto)
        {
            var userId = currentUser.GetId();
            var isUpdated = catService.Update(updateDto.Id, userId, updateDto.Description);
            if(!isUpdated)
            {
                return BadRequest();
            }
            return Ok();
        }
        [HttpDelete("Delete")]
        [Authorize]
        public async Task<ActionResult> Delete(int id)
        {
            var userId = currentUser.GetId();
            var isDeleted = catService.Delete(id, userId);
                   
            if (!isDeleted)
            {
                return BadRequest();
            }
            return Ok();
        }





    }
}
