using System.ComponentModel.DataAnnotations;

namespace XtraBlog.UI.Dtos.AdminDtos
{
    public class AdminCreateDto
    {
        [Required]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Min-4, max-50 characters!")]
        public string Name { get; set; }
        public string Description { get; set; }
        public string PhotoURL { get; set; }
        public string Position { get; set; }
    }
}
