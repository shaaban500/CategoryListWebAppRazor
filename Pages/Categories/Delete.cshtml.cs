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
    public class DeleteModel : PageModel
    {
        private readonly AppDbContext _db;

        [BindProperty]
        public Category Category { get; set; }

        public DeleteModel(AppDbContext db)
        {
            _db = db;
        }

        public void OnGet(int id)
        {
            Category = _db.Categories.Find(id);
        }

        public IActionResult OnPost()
        {
            var categoryFromDb = _db.Categories.Find(Category.Id);
            if (categoryFromDb != null)
            {
                _db.Categories.Remove(categoryFromDb);
                _db.SaveChanges();

                return RedirectToPage("Index");
            }
            return Page();
        }

    }
}
