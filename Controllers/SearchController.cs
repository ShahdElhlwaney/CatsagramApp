using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace CatstgramApp.Controllers
{
   
    public class SearchController : BaseController
    {
        private readonly ISearchService searchService;
        public SearchController(ISearchService searchService)
        {
            this.searchService = searchService;
        }
        [HttpGet]
        public IEnumerable<ProfileSearchServiceModel> Profiles(string query)
        =>searchService.Profiles(query);

    }
}
