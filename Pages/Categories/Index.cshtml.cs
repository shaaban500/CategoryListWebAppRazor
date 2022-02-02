using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUDAppRazorPages.Data;
using CRUDAppRazorPages.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CRUDAppRazorPages.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _db;
        
        public IEnumerable<Category> Categories { get; set; }

        public IndexModel(AppDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
            Categories = _db.Categories;
        }
    }
}
