using System;
using System.Collections.Generic;

namespace TennisScore
{
    public class TennisGame
    {
        private readonly IRepository<Game> _repo;

        private readonly Dictionary<int, string> _scoreLookUp = new Dictionary<int, string>
        {
            {0, "Love"},
            {1, "Fifteen"},
            {2, "Thirty"},
        };

        public TennisGame(IRepository<Game> repo)
        {
            _repo = repo;
        }

        public string ScoreResult(int gameId)
        {
            var game = _repo.GetGame(gameId);
            if (game.FirstPlayerScore == game.SecondPlayerScore)
            {
                return _scoreLookUp[game.FirstPlayerScore] + " All";
            }
            return "Love All";
        }
    }
}