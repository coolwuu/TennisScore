using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace TennisScore
{
    [TestClass]
    public class TennisScoreTest
    {
        private readonly int _anyGameId = 1;
        private readonly IRepository<Game> _repository = Substitute.For<IRepository<Game>>();
        private TennisGame _tennisGame;

        [TestInitialize]
        public void TestInit()
        {
            _tennisGame = new TennisGame(_repository);
        }

        [TestMethod]
        public void Love_All()
        {
            GivenScore(0, 0);
            ScoreShouldBe("Love All");
        }

        private void ScoreShouldBe(string expected)
        {
            var scoreResult = _tennisGame.ScoreResult(_anyGameId);
            Assert.AreEqual(expected, scoreResult);
        }

        private void GivenScore(int secondPlayerScore, int firstPlayerScore)
        {
            _repository.GetGame(_anyGameId).Returns(new Game {Id = _anyGameId, FirstPlayerScore = firstPlayerScore, SecondPlayerScore = secondPlayerScore});
        }
    }
}