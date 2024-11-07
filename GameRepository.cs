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

        public async Task<IEnumerable<GameType>> GetExistingTypesAsync(IEnumerable<GameType> types)
        {
            var typeNames = types.Select(t => t.Name).ToList();
            return await _context.GameTypes
                                 .Where(t => typeNames.Contains(t.Name))
                                 .ToListAsync();
        }

        public async Task AddGameTypeAsync(GameType type)
        {
            _context.GameTypes.Add(type);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Game>> GetAllGamesAsync(string gameType = null)
        {
            IQueryable<Game> query = _context.Games.Include(t => t.GameTypes);

            if (!string.IsNullOrEmpty(gameType))
            {
                query = query.Where(g => g.GameTypes.Any(type => type.Name == gameType));
            }

            return await query.ToListAsync();
        }

        public async Task<Game> GetGameByIdAsync(int id)
        {
            return await _context.Games
                .Include(game => game.GameTypes)
                .FirstOrDefaultAsync(game => game.Id == id);
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
