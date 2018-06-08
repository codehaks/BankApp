using BankApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BankApp.Pages
{
    public class IndexModel : PageModel
    {
        public IList<User> Users { get; set; }

        public void OnGet([FromServices] BankDbContext _db)
        {
            //Func<User, User> funcSelect = u => new User { Givenname = u.Givenname, Maidenname = u.Maidenname };

            //Users = _db.Users
            //  .Select(funcSelect)
            //  .Take(10).ToList();


            Expression<Func<User, User>> expSelect =  u => new User { Givenname = u.Givenname, Maidenname = u.Maidenname } ;   

            Users = _db.Users
                .Select(expSelect)                
                .Take(10).ToList();
        }
    }
}