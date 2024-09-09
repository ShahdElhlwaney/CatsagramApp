using Core.Entities.Identity;
using System.ComponentModel.DataAnnotations;
using static Core.Entities.Validation.Cat;

namespace CatstgramApp.Dtos
{
    public class CatDto
    {
        [MaxLength(MaxLengthDescription)]
        public string Description { get; set; }
        [Required]
        public string ImageUrl { get; set; }

        //public string UserId;
        public string? Name { get; set; }
      
    }
}
