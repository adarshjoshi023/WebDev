using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GG.Data;
using GG.Models;

namespace GG.Pages.Sports
{
    public class DetailsModel : PageModel
    {
        private readonly GG.Data.ApplicationDbContext _context;

        public DetailsModel(GG.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Sport Sport { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Sport == null)
            {
                return NotFound();
            }

            var sport = await _context.Sport.Include(c => c.playgrounds).Include(c=>c.players).Include(c=>c.refrees).FirstOrDefaultAsync(m => m.id == id);
            if (sport == null)
            {
                return NotFound();
            }
            else
            {
                Sport = sport;
            }
            return Page();
        }
    }
}
