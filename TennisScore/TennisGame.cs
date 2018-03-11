using System;
using System.Collections.Generic;

namespace TennisScore
{
    public class TennisGame
    {
        private readonly IRepository<Game> _repo;

        public TennisGame(IRepository<Game> repo)
        {
            _repo = repo;
        }

        public string ScoreResult(int gameId)
        {
            var game = _repo.GetGame(gameId);
            var scoreLookup = new Dictionary<int, string>
            {
                {0, "Love"},
                {1, "Fifteen"},
                {2, "Thirty"},
            };
            if (game.FirstPlayerScore == game.SecondPlayerScore)
            {
                return scoreLookup[game.FirstPlayerScore] + " All";
            }

            return "Love All";
        }
    }
}