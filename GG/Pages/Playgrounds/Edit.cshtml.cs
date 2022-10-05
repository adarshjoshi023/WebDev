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

namespace GG.Pages.Playgrounds
{
    public class EditModel : PageModel
    {
        private readonly GG.Data.ApplicationDbContext _context;

        public EditModel(GG.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Playground Playground { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Playground == null)
            {
                return NotFound();
            }

            var playground =  await _context.Playground.FirstOrDefaultAsync(m => m.Id == id);
            if (playground == null)
            {
                return NotFound();
            }
            Playground = playground;
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

            _context.Attach(Playground).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlaygroundExists(Playground.Id))
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

        private bool PlaygroundExists(int id)
        {
          return _context.Playground.Any(e => e.Id == id);
        }
    }
}
