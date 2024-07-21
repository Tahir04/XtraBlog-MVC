using Microsoft.AspNetCore.Mvc;

namespace XtraBlog.UI.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class OtherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
