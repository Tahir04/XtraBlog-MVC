using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XtraBlog.UI.Data;
using XtraBlog.UI.Dtos.AdminDtos;
using XtraBlog.UI.Models;

namespace XtraBlog.UI.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class AdminController : Controller
    {

        private readonly AppDbContext _context;

        public AdminController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var admins = _context.Admins.ToList();
            return View(admins);
        }
        public IActionResult Create()
        {
            return View();
        }

        // CREATE SECTION
        [HttpPost]
        public IActionResult Create(AdminCreateDto adminCreate)
        {

            if (ModelState.IsValid)
            {
                var admin = new Admin
                {
                    Name = adminCreate.Name,
                    Description = adminCreate.Description,
                    PhotoURL = adminCreate.PhotoURL,
                    Position = adminCreate.Position
                };
                _context.Admins.Add(admin);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adminCreate);
        }

        // EDIT SECTION - GET
        public IActionResult Edit(int id)
        {
            var admin = _context.Admins.Find(id);
            if (admin == null)
            {
                return NotFound();
            }

            var adminEditDto = new AdminEditDto
            {
                Id = admin.Id,
                Name = admin.Name,
                Description = admin.Description,
                PhotoURL = admin.PhotoURL,
                Position = admin.Position
            };

            return View(adminEditDto);
        }

        // EDIT SECTION - POST
        [HttpPost]
        public IActionResult Edit(AdminEditDto adminEditDto)
        {
            if (ModelState.IsValid)
            {
                var admin = _context.Admins.Find(adminEditDto.Id);
                if (admin == null)
                {
                    return NotFound();
                }

                admin.Name = adminEditDto.Name;
                admin.Description = adminEditDto.Description;
                admin.PhotoURL = adminEditDto.PhotoURL;
                admin.Position = adminEditDto.Position;

                _context.Entry(admin).State = EntityState.Modified;
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(adminEditDto);
        }

        // DELETE SECTION
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var admin = _context.Admins.Find(id);
            if (admin == null)
            {
                return NotFound();
            }

            _context.Admins.Remove(admin);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

