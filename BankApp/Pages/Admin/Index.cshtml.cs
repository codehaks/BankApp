using BankApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BankApp.Pages.Admin
{
    public class IndexModel : PageModel
    {
        public IList<User> Users { get; set; }

        public const int PageSize = 10;

        public int TotalPages { get; set; }

        [ViewData]
        public int PageNumber { get; set; }

        public void OnGet([FromServices] BankDbContext _db, int number = 1)
        {
            Expression<Func<User, User>> expSelect = u => new User { Givenname = u.Givenname, Maidenname = u.Maidenname };

            var skip = PageSize * (number - 1);

            TotalPages = _db.Users.Count() / PageSize;

            Users = _db.Users
                .Select(expSelect)
                .Skip(skip)
                .Take(PageSize)
                .ToList();

            PageNumber = number;
        }
    }
}