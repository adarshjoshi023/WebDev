using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GG.Data;
using GG.Models;
using System.Drawing.Printing;

namespace GG.Pages.Players
{
    public class CreateModel : PageModel
    {
        private readonly GG.Data.ApplicationDbContext _context;

        public CreateModel(GG.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public int GroundIdInput { get; set; }
        public int SportIdInput { get; set; }
        public IActionResult OnGet(int groundIdInput, int sportIdInput)
        {
            GroundIdInput = groundIdInput;
            
            SportIdInput = sportIdInput;
            ViewData["groundId"] = new SelectList(_context.Playground, "Id", "Id");
            ViewData["sportId"] = new SelectList(_context.Sport, "id", "id");
            return Page();
        }

        [BindProperty]
        public Player Player { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Player.Add(Player);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Sports/Index");
        }
    }
}
