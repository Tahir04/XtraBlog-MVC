namespace XtraBlog.UI.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PhotoURL { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
