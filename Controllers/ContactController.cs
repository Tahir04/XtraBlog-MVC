using Microsoft.AspNetCore.Mvc;
using XtraBlog.UI.Data;
using XtraBlog.UI.Models;

namespace XtraBlog.UI.Controllers
{
    public class ContactController : Controller
    {
        private readonly AppDbContext _contact;

        public ContactController(AppDbContext contact)
        {
            _contact = contact;
        }

        public IActionResult Index()
        {
            List<Contact> contacts = _contact.Contacts.ToList();
            return View(contacts);
        }

    }
}