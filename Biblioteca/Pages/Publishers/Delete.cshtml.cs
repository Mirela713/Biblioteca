using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Biblioteca.Data;
using Biblioteca.Models;

namespace Biblioteca.Pages.Publishers
{
    public class DeleteModel : PageModel
    {
        private readonly Biblioteca.Data.BibliotecaContext _context;

        public DeleteModel(Biblioteca.Data.BibliotecaContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Publisher Publisher { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Publishe == null)
            {
                return NotFound();
            }

            var publisher = await _context.Publishe.FirstOrDefaultAsync(m => m.Id == id);

            if (publisher == null)
            {
                return NotFound();
            }
            else 
            {
                Publisher = publisher;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Publishe == null)
            {
                return NotFound();
            }
            var publisher = await _context.Publishe.FindAsync(id);

            if (publisher != null)
            {
                Publisher = publisher;
                _context.Publishe.Remove(Publisher);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
