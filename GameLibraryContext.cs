using Microsoft.EntityFrameworkCore;

namespace GamesLibrary
{
    public class GameLibraryContext : DbContext
    {
        public GameLibraryContext(DbContextOptions<GameLibraryContext> options) : base(options) { }

        public DbSet<Game> Games { get; set; }
        public DbSet<GameType> GameTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>()
                .HasMany(e => e.GameTypes)
                .WithMany(e => e.Games);
        }
    }
}
