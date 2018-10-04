using BankApp.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BankApp.Controllers
{
    public class UserController : Controller
    {
        private readonly BankDbContext _db;
        public UserController(BankDbContext db)
        {
            _db = db;
        }
        [Route("/")]
        public IActionResult Index()
        {
            var model = _db.Users.Take(10);
            return View(model);
        }
    }
}