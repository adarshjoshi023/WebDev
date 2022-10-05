using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GG.Data;
using GG.Models;

namespace GG.Pages.Playgrounds
{
    public class CreateModel : PageModel
    {
        private readonly GG.Data.ApplicationDbContext _context;

        public CreateModel(GG.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public int SportIdInput { get; set; }

        public IActionResult OnGet(int sportIdInput)
        {
            SportIdInput = sportIdInput;
            ViewData["sportId"] = new SelectList(_context.Sport, "id", "id");
            return Page();
        }

        [BindProperty]
        public Playground Playground { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Playground.Add(Playground);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Sports/Index");
        }
    }
}
