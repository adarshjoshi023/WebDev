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
    public class IndexModel : PageModel
    {
        private readonly GG.Data.ApplicationDbContext _context;

        public IndexModel(GG.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Sport> Sport { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Sport != null)
            {
                Sport = await _context.Sport.ToListAsync();
            }
        }
    }
}
