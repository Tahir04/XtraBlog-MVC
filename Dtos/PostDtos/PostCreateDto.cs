using System.ComponentModel.DataAnnotations;

namespace XtraBlog.UI.Dtos.PostDtos
{
    public class PostCreateDto
    {
        [Required]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Min-4, max-50 characters!")]
        public string Title { get; set; }
        public string HomeDescription { get; set; }
        public string Description { get; set; }
        public string PhotoURL { get; set; }
        public string VideoURL { get; set; }
    }
}
