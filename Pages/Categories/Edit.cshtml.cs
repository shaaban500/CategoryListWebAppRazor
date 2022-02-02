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
    public class EditModel : PageModel
    {
        private readonly AppDbContext _db;

        [BindProperty]
        public Category Category { get; set; }

        public EditModel(AppDbContext db)
        {
            _db = db;
        }


        public void OnGet(int id)
        {
            Category = _db.Categories.Find(id);
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(Category);
                _db.SaveChanges();
                
                return RedirectToPage("Index");
            }
            return Page();
        }

    }
}
