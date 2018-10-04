using BankApp.Data;
using BankApp.Models;
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
        public IActionResult Index(UserFilter filter)
        {
            var model = _db.Users.Where(u => u.City == filter.City);
            return View(model);
        }

        public IActionResult Cities()
        {
            var model = _db.Users.Select(u => new { Name = u.City }).Distinct();
            return Ok(model);
        }
    }
}