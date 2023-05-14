using Mapster;
using Microsoft.EntityFrameworkCore;
using RankingCore.Persistence.Contexts;
using RankingCore.Persistence.Models;
using RankingCore.ViewEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RankingCore.Persistence.Repositories
{
    public class ScoreRepository : IScoreRepository, IDisposable
    {
        private RankingContext _rankingContext;
        private bool disposed = false;

        public ScoreRepository(RankingContext rankingContext) 
        {
            _rankingContext= rankingContext;
        }

        public async Task<ScoreDetails> RegisterScore(Score registerScore)
        {
            await _rankingContext.Scores.AddAsync(registerScore);
            await SaveAsync();
            return await GetLatestPlayerScore(registerScore.PlayerId);
        }

        public async Task<ScoreDetails> GetLatestPlayerScore(int playerId)
        {
            return (await _rankingContext.Scores.AsNoTracking().Where(x => x.PlayerId == playerId).OrderByDescending(x => x.ScoreRegisterDate).FirstOrDefaultAsync()).Adapt<ScoreDetails>();
        }

        public async Task<List<ScoreDetails>> GetPlayerScores(int playerId) 
        {
            var scores = await _rankingContext.Scores.AsNoTracking().Where(x => x.PlayerId == playerId).OrderBy(x => x.ScoreRegisterDate).ToListAsync();

            return scores.Select(x => x.Adapt<ScoreDetails>()).ToList();
        }

        public async Task<ScoreDetails> GetHighestScore()
        {
            return (await _rankingContext.Scores.AsNoTracking().OrderByDescending(x => x.ScoreRegisterDate).FirstOrDefaultAsync()).Adapt<ScoreDetails>();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _rankingContext.Dispose();
                }
            }
            this.disposed = true;
        }
        private async Task SaveAsync()
        {
            await _rankingContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
