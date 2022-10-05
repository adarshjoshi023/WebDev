using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GG.Data;
using GG.Models;

namespace GG.Pages.Players
{
    public class IndexModel : PageModel
    {
        private readonly GG.Data.ApplicationDbContext _context;

        public IndexModel(GG.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Player> Player { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Player != null)
            {
                Player = await _context.Player
                .Include(p => p.Playground)
                .Include(p => p.Sport).ToListAsync();
            }
        }
    }
}
