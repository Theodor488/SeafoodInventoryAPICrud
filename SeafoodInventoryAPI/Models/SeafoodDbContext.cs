using Microsoft.EntityFrameworkCore;

namespace SeafoodInventoryAPI.Models
{
    public class SeafoodDbContext : DbContext
    {
        public SeafoodDbContext(DbContextOptions<SeafoodDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Species>().ToTable("SpeciesTable");
            modelBuilder.Entity<Catches>().ToTable("CatchesTable");
        }

        public DbSet<Species> Species { get; set; }
        public DbSet<Catches> Catches { get; set; }
    }
}

