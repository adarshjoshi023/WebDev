using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GG.Data;
using GG.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace GG.Pages
{
    public class StatsModel : PageModel
    {
        private readonly GG.Data.ApplicationDbContext _context;

        public StatsModel(GG.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Sport> Sport { get;set; } = default!;
        public bool SearchCompleted { get; set; } = false;
        public string? Query { get; set; }

        public async Task OnGetAsync( string query)
        {
           
            if (_context.Sport != null)
            {
                Sport = await _context.Sport.Include(c=>c.players).Include(c=>c.playgrounds).ToListAsync();
                Query = query;
                if (!string.IsNullOrWhiteSpace(query))
                {
                    SearchCompleted = true;
                    Sport = await _context.Sport
                            .Where(x => x.sportName.StartsWith(query))
                            .ToListAsync();
                }
                else
                {
                    SearchCompleted = false;
                    Sport = new List<Sport>();
                }
            }

        }
    }
}
