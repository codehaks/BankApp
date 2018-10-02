using BankApp.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace BankApp.Controllers
{
    public class CompareController : Controller
    {
        private readonly BankDbContext _db;
        public CompareController(BankDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Route("compare/tolower")]
        public IActionResult ToLower()
        {

            var all = _db.Users.ToList();
            var now = DateTime.Now;
            int jacksCount = 0;

            for (int i = 0; i < 1000; i++)
            {
                jacksCount = all.Where(u => u.Givenname.ToLower() == "jack").Count();
            }

            var duration = (DateTime.Now - now).TotalSeconds;
            return Ok(jacksCount.ToString() + " , Time : " + duration);
        }


        [Route("compare/equal")]
        public IActionResult Equal()
        {

            var all = _db.Users.ToList();
            var now = DateTime.Now;
            int jacksCount = 0;
            for (int i = 0; i < 1000; i++)
            {
                jacksCount = all.Where(u => string.Equals(u.Givenname, "jack", StringComparison.OrdinalIgnoreCase)).Count();
            }

            var duration = (DateTime.Now - now).TotalSeconds;

            return Ok(jacksCount + " , Time : " + duration);
        }
    }
}