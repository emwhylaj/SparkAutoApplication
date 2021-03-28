using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SparkAuto.Data;
using SparkAuto.Models;

namespace SparkAuto.Pages.Users
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext db;

        public EditModel(ApplicationDbContext db)
        {
            this.db = db;
        }

        [BindProperty]
        public ApplicationUser ApplicationUser { get; set; }

        public async Task<IActionResult> OnGet(string id)
        {
            ApplicationUser = await db.ApplicationUsers.FindAsync(id);
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var user = await db.ApplicationUsers.FindAsync(ApplicationUser.Id);
                user.Name = ApplicationUser.Name;
                user.PhoneNumber = ApplicationUser.PhoneNumber;
                user.PostalCode = ApplicationUser.PostalCode;
                user.Address = ApplicationUser.Address;
                user.City = ApplicationUser.City;

                await db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}