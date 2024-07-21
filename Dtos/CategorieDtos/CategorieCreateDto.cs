using System.ComponentModel.DataAnnotations;
namespace XtraBlog.UI.Dtos.CategorieDtos
{
    public class CategorieCreateDto
    {
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Min-2, max-50 characters!")]
        public string Name { get; set; }
    }
}
