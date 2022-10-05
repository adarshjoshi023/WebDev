using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GG.Data;
using GG.Models;

namespace GG.Pages.Refrees
{
    public class DeleteModel : PageModel
    {
        private readonly GG.Data.ApplicationDbContext _context;

        public DeleteModel(GG.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Refree Refree { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Refree == null)
            {
                return NotFound();
            }

            var refree = await _context.Refree.FirstOrDefaultAsync(m => m.Id == id);

            if (refree == null)
            {
                return NotFound();
            }
            else 
            {
                Refree = refree;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Refree == null)
            {
                return NotFound();
            }
            var refree = await _context.Refree.FindAsync(id);

            if (refree != null)
            {
                Refree = refree;
                _context.Refree.Remove(Refree);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
