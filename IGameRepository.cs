namespace GamesLibrary
{
    public interface IGameRepository
    {
        Task<Game> AddGameAsync(Game game);
        Task<IEnumerable<Game>> GetAllGamesAsync(string genre = null);
        Task<Game> UpdateGameAsync(Game game);
        Task<bool> DeleteGameAsync(int id);
    }
}
