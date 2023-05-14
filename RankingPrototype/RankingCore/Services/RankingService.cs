using Mapster;
using RankingCore.Persistence.Models;
using RankingCore.Persistence.Repositories;
using RankingCore.ViewEntities;
using System.Web.Http;

namespace RankingCore.Services
{
    public class RankingService : IRankingService
    {
        private IPlayerRepository _playerRepository;
        private IScoreRepository _scoreRepository;
        public RankingService(IPlayerRepository playerRepository, IScoreRepository scoreRepository)
        {
            _playerRepository = playerRepository;
            _scoreRepository = scoreRepository;
        }

        public Task<ScoreDetails> GetHighestScore()
        {
            throw new NotImplementedException();
        }

        public async Task<PlayerDetails> GetPlayerDetails(int playerId)
        {
            if (await _playerRepository.PlayerExists(playerId))
            {
                return await _playerRepository.GetPlayerDetails(playerId);
            }
            throw new HttpResponseException(RankingServiceResponses.PlayerDoesNotExistResponse());
        }

        public async Task<ScoreDetails> GetLatestPlayerScore(int playerId)
        {
            if (await _playerRepository.PlayerExists(playerId))
            {
                return await _scoreRepository.GetLatestPlayerScore(playerId);
            }
            throw new HttpResponseException(RankingServiceResponses.PlayerDoesNotExistResponse());
        }

        public Task<List<PlayerDetails>> GetTop10Scores()
        {
            return _playerRepository.GetTop10Scores();
        }

        public async Task<PlayerDetails> RegisterPlayer(RegisterPlayer registerPlayer)
        {
            var newPlayer = registerPlayer.Adapt<Player>();
            newPlayer.UniquePlayerIdentifier = Guid.NewGuid();
            return await _playerRepository.RegisterPlayer(newPlayer);
        }

        public async Task<ScoreDetails> RegisterScore(RegisterScore registerScore)
        {
            PlayerDetails player = await _playerRepository.GetPlayerDetails(registerScore.PlayerId);
            if (player != null)
            {
                if (player.HighScore < registerScore.ScoreAmount)
                {
                    player.HighScore = registerScore.ScoreAmount;
                    player.LastHighScoreDate = DateTime.UtcNow;
                }
                player.TotalScore += registerScore.ScoreAmount;
                player.LastScoreDate = DateTime.UtcNow;

                var toRegister = registerScore.Adapt<Score>();
                toRegister.UniquePlayerIdentifier = player.UniquePlayerIdentifier;
                toRegister.ScoreRegisterDate = DateTime.UtcNow;

                await _playerRepository.UpdatePlayerDetails(player.Adapt<Player>());
                return await _scoreRepository.RegisterScore(toRegister);


            }
            throw new HttpResponseException(RankingServiceResponses.PlayerDoesNotExistResponse());
        }

        public async Task<List<ScoreDetails>> GetPlayerScores(int playerId)
        {
            if (await _playerRepository.PlayerExists(playerId))
            {
                return await _scoreRepository.GetPlayerScores(playerId);
            }
            throw new HttpResponseException(RankingServiceResponses.PlayerDoesNotExistResponse());
        }
    }
}
