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

        [TestMethod]
        public void Fifteen_All()
        {
            GivenScore(1, 1);
            ScoreShouldBe("Fifteen All");
        }

        [TestMethod]
        public void Thirty_All()
        {
            GivenScore(2, 2);
            ScoreShouldBe("Thirty All");
        }
        [TestMethod]
        public void Forty_All()
        {
            GivenScore(3, 3);
            ScoreShouldBe("Duece");
        }
        [TestMethod]
        public void Fifteen_Love()
        {
            GivenScore(1, 0);
            ScoreShouldBe("Fifteen Love");
        }

        private void ScoreShouldBe(string expected)
        {
            var scoreResult = _tennisGame.ScoreResult(_anyGameId);
            Assert.AreEqual(expected, scoreResult);
        }

        private void GivenScore(int firstPlayerScore,int secondPlayerScore)
        {
            _repository.GetGame(_anyGameId).Returns(new Game {Id = _anyGameId, FirstPlayerScore = firstPlayerScore, SecondPlayerScore = secondPlayerScore});
        }
    }
}