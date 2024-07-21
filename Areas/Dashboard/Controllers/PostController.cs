using Microsoft.AspNetCore.Mvc;
using XtraBlog.UI.Dtos.PostDtos;
using XtraBlog.UI.Data;
using XtraBlog.UI.Models;
using Microsoft.EntityFrameworkCore;
using XtraBlog.UI.Dtos.CategorieDtos;


namespace XtraBlog.UI.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class PostController : Controller
    {
        private readonly AppDbContext _context;

        public PostController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var posts = _context.Posts.ToList();
            return View(posts);
        }
        public IActionResult Create()
        {
            return View();
        }


        // CREATE SECTION
        [HttpPost]
        public IActionResult Create(PostCreateDto postCreate)
        {

            if (ModelState.IsValid)
            {
				var post = new Post
				{
					Title = postCreate.Title,
					HomeDescription = postCreate.HomeDescription,
					Description = postCreate.Description,
					PhotoURL = postCreate.PhotoURL,
					VideoURL = postCreate.VideoURL,
					CreatedDate = DateTime.Now,
					AdminId = 1
				};
				_context.Posts.Add(post);
				_context.SaveChanges();
                return RedirectToAction("Index");
			}
            return View(postCreate);
        }

        // EDIT SECTION - GET
        public IActionResult Edit(int id)
        {
            var post = _context.Posts.Find(id);
            if (post == null)
            {
                return NotFound();
            }

            var postEditDto = new PostEditDto
            {
                Id = post.Id,
                Title = post.Title,
                HomeDescription = post.HomeDescription,
                Description = post.Description,
                PhotoURL = post.PhotoURL,
                VideoURL = post.VideoURL,
                CreatedDate = DateTime.Now
            };

            return View(postEditDto);
        }
        // EDIT SECTION - POST
        [HttpPost]
        public IActionResult Edit(PostEditDto postEditDto)
        {

            postEditDto.AdminId = 1;
            var admin = _context.Admins.FirstOrDefault(x => x.Id == 1);
            postEditDto.Admin = admin;
            
                var post = _context.Posts.Find(postEditDto.Id);
                if (post == null)
                {
                    return NotFound();
                }

                post.Title = postEditDto.Title;
                post.HomeDescription = postEditDto.HomeDescription;
                post.Description = postEditDto.Description;
                post.PhotoURL = postEditDto.PhotoURL;
                post.VideoURL = postEditDto.VideoURL;

                _context.Entry(post).State = EntityState.Modified;
                _context.SaveChanges();

                return RedirectToAction("Index");

        }


        // DELETE SECTION
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var post = _context.Posts.Find(id);
            if (post == null)
            {
                return NotFound();
            }

            _context.Posts.Remove(post);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}


