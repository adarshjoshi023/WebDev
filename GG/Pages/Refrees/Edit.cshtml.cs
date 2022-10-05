using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GG.Data;
using GG.Models;

namespace GG.Pages.Refrees
{
    public class EditModel : PageModel
    {
        private readonly GG.Data.ApplicationDbContext _context;

        public EditModel(GG.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Refree Refree { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Refree == null)
            {
                return NotFound();
            }

            var refree =  await _context.Refree.FirstOrDefaultAsync(m => m.Id == id);
            if (refree == null)
            {
                return NotFound();
            }
            Refree = refree;
           ViewData["groundId"] = new SelectList(_context.Playground, "Id", "Id");
           ViewData["sportId"] = new SelectList(_context.Set<Sport>(), "id", "id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Refree).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RefreeExists(Refree.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool RefreeExists(int id)
        {
          return _context.Refree.Any(e => e.Id == id);
        }
    }
}
