using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GG.Data;
using GG.Models;

namespace GG.Pages.Playgrounds
{
    public class DetailsModel : PageModel
    {
        private readonly GG.Data.ApplicationDbContext _context;

        public DetailsModel(GG.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Playground Playground { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Playground == null)
            {
                return NotFound();
            }

            var playground = await _context.Playground.FirstOrDefaultAsync(m => m.Id == id);
            if (playground == null)
            {
                return NotFound();
            }
            else 
            {
                Playground = playground;
            }
            return Page();
        }
    }
}
