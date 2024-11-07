namespace GamesLibrary
{
    public interface IGameRepository
    {
        Task<Game> AddGameAsync(Game game);
        Task<IEnumerable<GameType>> GetExistingTypesAsync(IEnumerable<GameType> gameTypes);
        Task AddGameTypeAsync(GameType gameType);
        Task<IEnumerable<Game>> GetAllGamesAsync(string type = null);
        Task<Game> GetGameByIdAsync(int id);
        Task<Game> UpdateGameAsync(Game game);
        Task<bool> DeleteGameAsync(int id);
    }
}
