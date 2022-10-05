using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GG.Models;

namespace GG.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<GG.Models.Player> Player { get; set; }
        public DbSet<GG.Models.Playground> Playground { get; set; }
        public DbSet<GG.Models.Refree> Refree { get; set; }
        public DbSet<GG.Models.Sport> Sport { get; set; }
    }
}