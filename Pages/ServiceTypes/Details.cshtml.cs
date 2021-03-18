using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SparkAuto.Data;

namespace SparkAuto.Pages.ServiceTypes
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext db;

        public DetailsModel(ApplicationDbContext db)
        {
            this.db = db;
        }

        [BindProperty]
        public Models.ServiceType ServiceType { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ServiceType = await db.ServiceTypes.FindAsync(id);

            if (ServiceType == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}