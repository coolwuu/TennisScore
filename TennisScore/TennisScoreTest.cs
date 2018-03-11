using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace TennisScore
{
    [TestClass]
    public class TennisScoreTest
    {
        private readonly int _anyGameId = 1;
        private readonly IRepository<Game> _repository = Substitute.For<IRepository<Game>>();

        [TestMethod]
        public void Love_All()
        {
            GivenScore(0, 0);

            TennisGame tennisGame = new TennisGame(_repository);

            var scoreResult = tennisGame.ScoreResult(_anyGameId);
            Assert.AreEqual("Love All", scoreResult);
        }

        private void GivenScore(int secondPlayerScore, int firstPlayerScore)
        {
            _repository.GetGame(_anyGameId).Returns(new Game {Id = _anyGameId, FirstPlayerScore = firstPlayerScore, SecondPlayerScore = secondPlayerScore});
        }
    }
}