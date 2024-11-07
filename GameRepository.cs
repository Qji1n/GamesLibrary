using Microsoft.EntityFrameworkCore;

namespace GamesLibrary
{
    public class GameRepository : IGameRepository
    {
        private readonly GameLibraryContext _context;

        public GameRepository(GameLibraryContext context)
        {
            _context = context;
        }

        public async Task<Game> AddGameAsync(Game game)
        {
            _context.Games.Add(game);
            await _context.SaveChangesAsync();
            return game;
        }

        public async Task<IEnumerable<Game>> GetAllGamesAsync(string gameType = null)
        {
            IQueryable<Game> query = _context.Games.Include(g => g.GameTypes);

            if (!string.IsNullOrEmpty(gameType))
            {
                query = query.Where(g => g.GameTypes.Any(type => type.Name == gameType));
            }

            return await query.ToListAsync();
        }

        public async Task<Game> UpdateGameAsync(Game game)
        {
            _context.Games.Update(game);
            await _context.SaveChangesAsync();
            return game;
        }

        public async Task<bool> DeleteGameAsync(int id)
        {
            var game = await _context.Games.FindAsync(id);
            if (game == null) return false;

            _context.Games.Remove(game);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}
