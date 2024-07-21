using XtraBlog.UI.Models;

namespace XtraBlog.UI.ViewModels
{
    public class HomeViewModel
    {
        public List<Post> Posts { get; set; }
        public List<PostGenre> PostGenres { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
    }
}
