using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XtraBlog.UI.Data;
using XtraBlog.UI.Models;
using System.Threading.Tasks;
using XtraBlog.UI.Dtos.CategorieDtos;
using System.Linq;

namespace XtraBlog.UI.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class CategorieController : Controller
    {
        private readonly AppDbContext _context;

        public CategorieController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var categories = _context.Categories.ToList();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        // CREATE SECTION
        [HttpPost]
        public IActionResult Create(CategorieCreateDto categorieCreate)
        {
            if (ModelState.IsValid)
            {
                var categorie = new Categorie
                {
                    Name = categorieCreate.Name
                };
                _context.Categories.Add(categorie);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categorieCreate);
        }

        // EDIT SECTION - GET
        public IActionResult Edit(int id)
        {
            var categorie = _context.Categories.Find(id);
            if (categorie == null)
            {
                return NotFound();
            }

            var categorieEditDto = new CategorieEditDto
            {
                Id = categorie.Id,
                Name = categorie.Name
            };

            return View(categorieEditDto);
        }

        // EDIT SECTION - POST
        [HttpPost]
        public IActionResult Edit(CategorieEditDto categorieEditDto)
        {
            if (ModelState.IsValid)
            {
                var categorie = _context.Categories.Find(categorieEditDto.Id);
                if (categorie == null)
                {
                    return NotFound();
                }

                categorie.Name = categorieEditDto.Name;

                _context.Entry(categorie).State = EntityState.Modified;
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(categorieEditDto);
        }

        // DELETE SECTION
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var categorie = _context.Categories.Find(id);
            if (categorie == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(categorie);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
