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
    public class IndexModel : PageModel
    {
        private readonly GG.Data.ApplicationDbContext _context;

        public IndexModel(GG.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Refree> Refree { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Refree != null)
            {
                Refree = await _context.Refree
                .Include(r => r.Playground)
                .Include(r => r.Sport).ToListAsync();
            }
        }
    }
}
