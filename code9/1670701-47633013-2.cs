    internal class TestMappingDrivers
    {
        [Test]
        public void WhenTargetIsDriverAndSourceIsDriver_Score1GetsValueFromScore1()
        {
            int score1 = 666;
            var source = new Score
            {
                Score1 = score1,
                Score2 = 667
            };
            var destination = new Score();
            MappingDrivers.Move(source, "Driver", destination, "Driver");
            Assert.AreEqual(score1, destination.Score2);    // Intentionally failing, it should be Assert.AreEqual(score1, destination.Score1);
        }
        [Test]
        public void WhenTargetIsDriverAndSourceIsSomethingElse_Score1GetsValueFromScore2()
        {
            int score2 = 667;
            var source = new Score
            {
                Score1 = 666,
                Score2 = score2
            };
            var destination = new Score();
            MappingDrivers.Move(source, "SomethingElse", destination, "Driver");
            Assert.AreEqual(score2, destination.Score1);   // Passing
        }
        [Test]
        public void WhenTargetIsCoDriverAndSourceIsDriver_Score1GetsValueFromScore1()
        {
            int score1 = 666;
            var source = new Score
            {
                Score1 = score1,
                Score2 = 667
            };
            var destination = new Score();
            MappingDrivers.Move(source, "Driver", destination, "CoDriver");
            Assert.AreEqual(score1, destination.Score2);   // Passing
        }
        [Test]
        public void WhenTargetIsCoDriverAndSourceIsSomethingElse_Score1GetsValueFromScore2()
        {
            int score2 = 667;
            var source = new Score
            {
                Score1 = 666,
                Score2 = score2
            };
            var destination = new Score();
            MappingDrivers.Move(source, "SomethingElse", destination, "CoDriver");
            Assert.AreEqual(score2, destination.Score2);   // Passing
        }
    }
