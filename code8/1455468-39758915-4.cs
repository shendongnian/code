    [TestFixture]
    public class TestRandom
    {
        [Test]
        public void Tests()
        {
            var random = new Random();
            double rnd;
            rnd = random.RangeWithExclusions(new Range(0, 1));
            Assert.IsTrue(rnd >= 0 && rnd <= 1);
            rnd = random.RangeWithExclusions(new Range(-100, 1));
            Assert.IsTrue(rnd >= -100 && rnd <= 1);
            rnd = random.RangeWithExclusions(new Range(0, 1), new Range(0.1, 0.9));
            Assert.IsTrue(rnd >= 0 && rnd <= 1 && (rnd <= 0.1 || rnd >= 0.9));
            rnd = random.RangeWithExclusions(new Range(0, 1), new Range(0, 0.9));
            Assert.IsTrue(rnd >= 0 && rnd <= 1 && (rnd >= 0.9));
            rnd = random.RangeWithExclusions(new Range(0, 1), new Range(0.2, 0.4), new Range(0.6, 0.8));
            Assert.IsTrue(rnd >= 0 && rnd <= 1 && (rnd <= 0.2 || rnd >= 0.4) && (rnd <= 0.6 || rnd >= 0.8));
        }
    }
