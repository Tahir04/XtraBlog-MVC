using Microsoft.EntityFrameworkCore;
using XtraBlog.UI.Models;

namespace XtraBlog.UI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<PostGenre> PostGenres { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Paramether> Paramethers { get; set; }

    }
}
