using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SparkAuto.Data;

namespace SparkAuto.Pages.ServiceTypes
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext db;

        public CreateModel(ApplicationDbContext db)
        {
            this.db = db;
        }
        public Models.ServiceType ServiceType { get; set; }
        public void OnGet()
        {
        }
    }
}
