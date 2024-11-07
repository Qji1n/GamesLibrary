namespace GamesLibrary
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Developer { get; set; }
        public List<GameType> GameTypes { get; set; } = new List<GameType>();
    }

    public class GameType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Game>? Games { get; set; }
    }
}