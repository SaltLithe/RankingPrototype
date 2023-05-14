using RankingCore.Persistence.Models;
using RankingCore.ViewEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RankingCore.Persistence.Repositories
{
    public interface IPlayerRepository : IDisposable
    {
        Task<PlayerDetails> RegisterPlayer(Player registerPlayer);
        Task<PlayerDetails> GetPlayerDetails(int playerId);
        Task UpdatePlayerDetails(Player playerDetails);
        Task<bool> PlayerExists(int playerId);
        Task<List<PlayerDetails>> GetTop10Scores();

    }
}
