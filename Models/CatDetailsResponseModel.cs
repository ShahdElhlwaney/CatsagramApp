using Core.Entities.Identity;
using System.ComponentModel.DataAnnotations;

namespace CatstgramApp.Models
{
    public class CatDetailsResponseModel : CatListingResponseModel
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string UserId { get; set; }
    }
}
