using Microsoft.AspNetCore.Mvc;
using XtraBlog.UI.Data;
using XtraBlog.UI.ViewModels;

namespace XtraBlog.UI.Controllers
{
    public class AboutController : Controller
    {
        private readonly AppDbContext _about;
        private readonly AppDbContext _aboutAdmin;
        private readonly AppDbContext _paramether;

        public AboutController(AppDbContext about, AppDbContext aboutAdmin, AppDbContext paramether)
        {
            _about = about;
            _aboutAdmin = aboutAdmin;
            _paramether = paramether;
        }
        public IActionResult Index()
        {
            var viewModel = new AboutViewModel
            {
                Abouts = _about.Abouts.ToList(),
                AboutAdmins = _aboutAdmin.Admins.ToList(),
                Paramethers = _paramether.Paramethers.ToList()
            };
            return View(viewModel);
        }
    }
}
