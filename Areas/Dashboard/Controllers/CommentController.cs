using Microsoft.AspNetCore.Mvc;
using XtraBlog.UI.Data;

namespace XtraBlog.UI.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class CommentController : Controller
    {
        private readonly AppDbContext _context;

        public CommentController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var comments = _context.Comments.ToList();
            return View(comments);
        }

        // DELETE SECTION
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var comment = _context.Comments.Find(id);
            if (comment == null)
            {
                return NotFound();
            }
            _context.Comments.Remove(comment);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
