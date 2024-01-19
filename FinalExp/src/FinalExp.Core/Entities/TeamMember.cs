using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace FinalExp.Core.Entities
{
    public class TeamMember:BaseEntity
    {
        [StringLength(maximumLength: 50)]
        [Required]
        public string Name { get; set; }
        [StringLength(maximumLength: 50)]
        [Required]
        public string Profession { get; set; }
        public string? ImageUrl { get; set; }
        [NotMapped]
        public IFormFile Image { get; set; }
    }
}
