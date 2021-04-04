using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListing_Core_POC.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListing_Core_POC.Pages.BookPages
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDBContext _db;

        public CreateModel(ApplicationDBContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Book Book { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            Console.WriteLine("Inside Post after submit ************** ");
            if (ModelState.IsValid)
            {
                await _db.Book.AddAsync(Book);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }

        }
    }
}
