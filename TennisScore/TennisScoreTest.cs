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
            GivenGame(new Game { Id = _anyGameId, FirstPlayerScore = 0, SecondPlayerScore = 0 });
            ScoreShouldBe("Love All");
        }

        [TestMethod]
        public void Fifteen_All()
        {
            GivenGame(new Game { Id = _anyGameId, FirstPlayerScore = 1, SecondPlayerScore = 1 });
            ScoreShouldBe("Fifteen All");
        }

        [TestMethod]
        public void Thirty_All()
        {
            GivenGame(new Game { Id = _anyGameId, FirstPlayerScore = 2, SecondPlayerScore = 2 });
            ScoreShouldBe("Thirty All");
        }
        [TestMethod]
        public void Forty_All()
        {
            GivenGame(new Game { Id = _anyGameId, FirstPlayerScore = 3, SecondPlayerScore = 3 });
            ScoreShouldBe("Duece");
        }

        [TestMethod]
        public void Fifteen_Love()
        {
            GivenGame(new Game { Id = _anyGameId, FirstPlayerScore = 1, SecondPlayerScore = 0 });
            ScoreShouldBe("Fifteen Love");
        }

        [TestMethod]
        public void Fifteen_Thirty()
        {
            GivenGame(new Game { Id = _anyGameId, FirstPlayerScore = 1, SecondPlayerScore = 2 });
            ScoreShouldBe("Fifteen Thirty");
        }

        [TestMethod]
        public void Forty_Thirty()
        {
            GivenGame(new Game { Id = _anyGameId, FirstPlayerScore = 3, SecondPlayerScore = 2 });
            ScoreShouldBe("Forty Thirty");
        }

        [TestMethod]
        public void FirstPlayerAdv()
        {
            GivenGame(new Game { Id = _anyGameId, FirstPlayerScore = 4, SecondPlayerScore = 3, FirstPlayerName = "Wuu" });
            ScoreShouldBe("Wuu Adv");
        }

        [TestMethod]
        public void SecondPlayerAdv()
        {
            GivenGame(new Game { Id = _anyGameId, FirstPlayerScore = 3, SecondPlayerScore = 4, SecondPlayerName = "Lily" });
            ScoreShouldBe("Lily Adv");
        }
        [TestMethod]
        public void FirstPlayerWin()
        {
            GivenGame(new Game { Id = _anyGameId, FirstPlayerScore = 5, SecondPlayerScore = 3, FirstPlayerName = "Wuu" });
            ScoreShouldBe("Wuu Win");
        }

        private void ScoreShouldBe(string expected)
        {
            var scoreResult = _tennisGame.ScoreResult(_anyGameId);
            Assert.AreEqual(expected, scoreResult);
        }

        private void GivenGame(Game game)
        {
            _repository.GetGame(_anyGameId).Returns(game);
        }
    }
}