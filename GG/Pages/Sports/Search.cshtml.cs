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
    public class SearchModel : PageModel
    {
        private readonly GG.Data.ApplicationDbContext _context;

        public SearchModel(GG.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Sport> Sport { get;set; } = default!;
        public bool SearchCompleted { get; set; }
        public string? Query { get; set; }


        public async Task OnGetAsync(string query)
        {
            Query=query;
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
                Sport= new List<Sport>();
            }
        }
    }
}
