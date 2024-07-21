namespace XtraBlog.UI.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string HomeDescription { get; set; }
        public string Description { get; set; }
        public string PhotoURL { get; set; }
        public string VideoURL { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ViewCount { get; set; }
        public int AdminId { get; set; }
        public Admin Admin { get; set; }
    }
}
