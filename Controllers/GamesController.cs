using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GamesLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGameRepository _gameRepository;

        public GamesController(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        // GET: api/<GamesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Game>>> GetGames([FromQuery] string genre)
        {
            var games = await _gameRepository.GetAllGamesAsync(genre);
            return Ok(games);
        }

        // GET api/<GamesController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<GamesController>
        [HttpPost]
        public async Task<ActionResult<Game>> CreateGame(Game game)
        {
            var newGame = await _gameRepository.AddGameAsync(game);
            return CreatedAtAction(nameof(GetGames), new { id = newGame.Id }, newGame);
        }

        // PUT api/<GamesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGame(int id, Game game)
        {
            if (id != game.Id) return BadRequest();

            await _gameRepository.UpdateGameAsync(game);
            return NoContent();
        }

        // DELETE api/<GamesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGame(int id)
        {
            var success = await _gameRepository.DeleteGameAsync(id);
            if (!success) return NotFound();

            return NoContent();
        }
    }
}
