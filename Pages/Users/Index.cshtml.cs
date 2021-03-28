using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SparkAuto.Data;
using SparkAuto.Models;
using SparkAuto.Utility;

namespace SparkAuto.Pages.Users
{
    [Authorize(Roles = SD.AdminEndUser)]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext db;

        public IndexModel(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IList<ApplicationUser> ApplicationUsersList { get; set; }

        public async Task<IActionResult> OnGet(string searchName, string searchPhone, string searchEmail)

        {
            if (searchName is null)
            {
                searchName = "";
            }
            if (searchPhone is null)
            {
                searchPhone = "";
            }
            if (searchEmail is null)
            {
                searchEmail = "";
            }

            ApplicationUsersList = await db.ApplicationUsers
                .Where(
                m => m.Name.ToLower().Contains(searchName.ToLower()) &&
                  m.PhoneNumber.ToLower().Contains(searchPhone.ToLower()) &&
                   m.Email.ToLower().Contains(searchEmail.ToLower())
                )
                .ToListAsync();
            return Page();
        }
    }
}