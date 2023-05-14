using RankingCore.ViewEntities;

namespace RankingCore.Services
{
    public interface IRankingService
    {
        Task<PlayerDetails> RegisterPlayer(RegisterPlayer registerPlayer);
        Task<PlayerDetails> GetPlayerDetails(int playerId);
        Task<ScoreDetails> RegisterScore(RegisterScore registerScore);
        Task<ScoreDetails> GetLatestPlayerScore(int playerId);
        Task<List<ScoreDetails>> GetPlayerScores(int playerId);
        Task<ScoreDetails> GetHighestScore();
        Task<List<PlayerDetails>> GetTop10Scores();
    }
}