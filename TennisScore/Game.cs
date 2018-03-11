using System;
using System.Collections.Generic;

namespace TennisScore
{
    public class Game
    {
        private readonly Dictionary<int, string> _scoreLookUp = new Dictionary<int, string>
        {
            {0, "Love"},
            {1, "Fifteen"},
            {2, "Thirty"},
            {3, "Forty"},
        };

        private const string Duece = "Duece";

        public string FirstPlayerName { get; set; }
        public int FirstPlayerScore { get; set; }
        public int Id { get; set; }
        public string SecondPlayerName { get; set; }
        public int SecondPlayerScore { get; set; }

        public bool IsSameScore()
        {
            return FirstPlayerScore == SecondPlayerScore;
        }

        public string ScoreResult()
        {
            return IsSameScore()
                ? (IsDuece() ? Duece : SameScoreLookup())
                : (IsReadyForWin() ? AdvanceState() : DiffScoreLookUp());
        }

        private string AdvanceState()
        {
            return IsAdvance() ? AdvPlayer() + " Adv" : AdvPlayer() + " Win";
        }

        private string AdvPlayer()
        {
            return FirstPlayerScore > SecondPlayerScore
                ? FirstPlayerName
                : SecondPlayerName;
        }

        private string DiffScoreLookUp()
        {
            return _scoreLookUp[FirstPlayerScore] + " " + _scoreLookUp[SecondPlayerScore];
        }

        private bool IsAdvance()
        {
            return Math.Abs(FirstPlayerScore - SecondPlayerScore) == 1;
        }

        private bool IsDuece()
        {
            return FirstPlayerScore >= 3;
        }

        private bool IsReadyForWin()
        {
            return FirstPlayerScore > 3 || SecondPlayerScore > 3;
        }
        private string SameScoreLookup()
        {
            return _scoreLookUp[FirstPlayerScore] + " All";
        }
    }
}