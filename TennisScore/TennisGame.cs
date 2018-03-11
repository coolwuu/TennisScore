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
            if (IsSameScore(game))
            {
                if (IsDuece(game))
                    return "Duece";
                return SameScoreLookup(game);
            }
            return "Love All";
        }

        private string SameScoreLookup(Game game)
        {
            return _scoreLookUp[game.FirstPlayerScore] + " All";
        }

        private static bool IsSameScore(Game game)
        {
            return game.FirstPlayerScore == game.SecondPlayerScore;
        }

        private static bool IsDuece(Game game)
        {
            return game.FirstPlayerScore >= 3;
        }
    }
}