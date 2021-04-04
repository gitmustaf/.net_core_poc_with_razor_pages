using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListing_Core_POC.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListing_Core_POC.Pages.BookPages
{
    public class EditModel : PageModel
    {
        public ApplicationDBContext _db;

        public EditModel(ApplicationDBContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Book Book { get; set; }
        
        public async Task OnGet(int id)
        {
            Book = await _db.Book.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var findBook = await _db.Book.FindAsync(Book.Id);
                findBook.Name = Book.Name;
                findBook.Author = Book.Author;
                findBook.ISBN = Book.ISBN;

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
