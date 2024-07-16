using Microsoft.EntityFrameworkCore;
using RelicMaster.Domain.Entity;

namespace RelicMaster.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Relic> Relics { get; set; }
    }
}
