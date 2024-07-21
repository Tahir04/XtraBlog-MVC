using Microsoft.AspNetCore.Mvc;
using XtraBlog.UI.Data;
using XtraBlog.UI.Models;
using System.Linq;

namespace XtraBlog.UI.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var postCount = _context.Posts.Count();
            var commentCount = _context.Comments.Count();
            var categoryCount = _context.Categories.Count();
            var adminCount = _context.Admins.Count();

            var model = new DashboardViewModel
            {
                PostCount = postCount,
                CommentCount = commentCount,
                CategoryCount = categoryCount,
                AdminCount = adminCount,
            };

            return View(model);
        }
    }

    public class DashboardViewModel
    {
        public int PostCount { get; set; }
        public int CommentCount { get; set; }
        public int CategoryCount { get; set; }
        public int AdminCount { get; set; }
    }
}