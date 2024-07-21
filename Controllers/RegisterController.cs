using Microsoft.AspNetCore.Mvc;

namespace XtraBlog.UI.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
