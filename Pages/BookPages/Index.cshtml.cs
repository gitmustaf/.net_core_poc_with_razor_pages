using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListing_Core_POC.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookListing_Core_POC.Pages.BookPages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDBContext _db;

        public IndexModel(ApplicationDBContext db)
        {
            _db = db;
        }

        public IEnumerable<Book> Books { get; set; }
        public async Task OnGet()
        {
            Books = await _db.Book.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            Book book = await _db.Book.FindAsync(id);
            if(book != null)
            {
                _db.Book.Remove(book);
                await _db.SaveChangesAsync();

            }
            else
            {
                return NotFound();
            }

            return RedirectToPage();
        }
    }
}
