using Microsoft.AspNetCore.Mvc;
using XtraBlog.UI.Data;
using XtraBlog.UI.Models;
using XtraBlog.UI.ViewModels;
using System.Linq;

namespace XtraBlog.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int page = 1, int pageSize = 4)
        {
            var totalPosts = _context.Posts.Count();
            var posts = _context.Posts
                                .Skip((page - 1) * pageSize)
                                .Take(pageSize)
                                .ToList();

            var viewModel = new HomeViewModel
            {
                Posts = posts,
                PostGenres = _context.PostGenres.ToList(),
                TotalPages = (int)Math.Ceiling((double)totalPosts / pageSize),
                CurrentPage = page
            };

            return View(viewModel);
        }

        public IActionResult Detail(int id)
        {
            var post = _context.Posts.FirstOrDefault(x => x.Id == id);
            var viewModel = new DetailViewModel
            {
                Post = post,
                Categories = _context.Categories.ToList(),
                Comments = _context.Comments.Where(c => c.Id == id).ToList()
            };
            return View(viewModel);
        }
    }
}
