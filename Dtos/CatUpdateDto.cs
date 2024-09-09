using System.ComponentModel.DataAnnotations;
using static Core.Entities.Validation.Cat;
namespace CatstgramApp.Dtos
{
    public class CatUpdateDto
    {
        [Required]
        public int Id { get; set; }
        [MaxLength(MaxLengthDescription)]      
        public string Description { get; set; }
        
    }
}
