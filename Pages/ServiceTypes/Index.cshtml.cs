using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SparkAuto.Data;


namespace SparkAuto.Pages.ServiceType
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext db;

        public IndexModel(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IList<Models.ServiceType> ServiceTypes { get; set; }
        public async Task<IActionResult>OnGetAsync()
        {
            ServiceTypes = await db.ServiceTypes.ToListAsync();
            return Page();
        }
    }
}
