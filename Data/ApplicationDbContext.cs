using FootballLeague.Models;
using Microsoft.EntityFrameworkCore;

namespace FootballLeague.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Match> Matches { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Match>().HasOne(x => x.HomeTeam)
                        .WithMany(x => x.HomeMatches)
                        .HasForeignKey(x => x.HomeTeamId);

            modelBuilder.Entity<Match>().HasOne(x => x.AwayTeam)
                        .WithMany(x => x.AwayMatches)
                        .HasForeignKey(x => x.AwayTeamId);
                 
        }
    }
}
