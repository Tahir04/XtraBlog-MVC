using XtraBlog.UI.Models;

namespace XtraBlog.UI.ViewModels
{
    public class DetailViewModel
    {
        public Post Post { get; set; }
        public List<Categorie> Categories { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
