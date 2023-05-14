using Microsoft.AspNetCore.Mvc;
using RankingCore.Persistence.Contexts;
using RankingCore.Services;
using RankingCore.ViewEntities;
using RankingPrototype.Filters;

namespace RankingPrototype.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [ServiceFilter(typeof(RankingExceptionFilter))]
    public class RankingPrototypeController : ControllerBase
    {
        private IRankingService _rankingService;

        private readonly ILogger<RankingPrototypeController> _logger;

        public RankingPrototypeController(ILogger<RankingPrototypeController> logger, IRankingService rankingService)
        {
            RankingContext context = new RankingContext();
            _rankingService = rankingService;
            _logger = logger;
        }
        [HttpPost]
        [Route("RegisterPlayer")]
        public async Task<PlayerDetails> RegisterPlayer([FromBody] RegisterPlayer registerPlayer)
        {
            return await _rankingService.RegisterPlayer(registerPlayer);
        }

        [HttpGet]
        [Route("PlayerDetails")]
        public async Task<PlayerDetails> GetPlayerDetails(int playerId)
        {
            return await _rankingService.GetPlayerDetails(playerId);
        }

        [HttpPost]
        [Route("RegisterScore")]
        public async Task<ScoreDetails> RegisterScore([FromBody] RegisterScore scoreDetails) 
        {
            return await _rankingService.RegisterScore(scoreDetails);
        }

        [HttpGet]
        [Route("GetLatestPlayerScore")]
        public async Task<ScoreDetails> GetLatestPlayerScore(int playerId) 
        {
            return await _rankingService.GetLatestPlayerScore(playerId);
        }

        [HttpGet]
        [Route("GetPlayerScores")]
        public async Task<List<ScoreDetails>> GetPlayerScores(int playerId) 
        {
            return await _rankingService.GetPlayerScores(playerId);
        }

        [HttpGet]
        [Route("GetTop10Scores")]
        public async Task<List<PlayerDetails>> GetTop10Scores() 
        {
            return await _rankingService.GetTop10Scores();
        }
    }
}