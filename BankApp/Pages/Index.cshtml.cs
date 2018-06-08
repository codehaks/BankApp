using BankApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace BankApp.Pages
{
    public class IndexModel : PageModel
    {
        public IList<User> Users { get; set; }

        public void OnGet([FromServices] BankDbContext _db)
        {
            Users = _db.Users.Take(100).ToList();
        }
    }
}