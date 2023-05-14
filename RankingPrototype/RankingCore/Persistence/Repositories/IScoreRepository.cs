using RankingCore.Persistence.Models;
using RankingCore.ViewEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RankingCore.Persistence.Repositories
{
    public interface IScoreRepository : IDisposable
    {
        Task<ScoreDetails> RegisterScore(Score score);
        Task<ScoreDetails> GetLatestPlayerScore(int playerId);
        Task<List<ScoreDetails>> GetPlayerScores(int playerId);
        Task<ScoreDetails> GetHighestScore();
    }
}
