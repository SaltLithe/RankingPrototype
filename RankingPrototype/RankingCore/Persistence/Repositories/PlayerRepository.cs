using Mapster;
using Microsoft.EntityFrameworkCore;
using RankingCore.Persistence.Contexts;
using RankingCore.Persistence.Models;
using RankingCore.ViewEntities;

namespace RankingCore.Persistence.Repositories
{
    public class PlayerRepository : IPlayerRepository, IDisposable
    {
        private RankingContext _rankingContext;
        private bool disposed = false;

        public PlayerRepository(RankingContext rankingContext)
        {
            _rankingContext = rankingContext;
        }

        public async Task<PlayerDetails> GetPlayerDetails(int playerId)
        {
            return (await _rankingContext.Players.AsNoTracking().Where(x => x.Id == playerId).FirstOrDefaultAsync()).Adapt<PlayerDetails>();
        }

        public async Task<PlayerDetails> RegisterPlayer(Player newPlayer)
        {
            _rankingContext.Players.Add(newPlayer);
            await SaveAsync();
            return await GetLatestPlayer();
        }

        public async Task UpdatePlayerDetails(Player playerDetails)
        {
            _rankingContext.Players.Update(playerDetails);
            await SaveAsync();
        }

        public async Task<bool> PlayerExists(int playerId)
        {
            return await _rankingContext.Players.AsNoTracking().Where(x => x.Id == playerId).AnyAsync();
        }
        public async Task<List<PlayerDetails>> GetTop10Scores()
        {
            var scores = await _rankingContext.Players.AsNoTracking().OrderByDescending(x => x.HighScore).Take(10).ToListAsync();

            return scores.Select(x => x.Adapt<PlayerDetails>()).ToList();
        }
        private async Task<PlayerDetails> GetLatestPlayer()
        {
            return (await _rankingContext.Players.AsNoTracking().OrderByDescending(x => x.Id).FirstOrDefaultAsync()).Adapt<PlayerDetails>();
        }
        private async Task SaveAsync()
        {
            await _rankingContext.SaveChangesAsync();
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

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
