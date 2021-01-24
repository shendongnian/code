    [TestClass]
    public class TimeSpanWithTypeComparisonTests
    {
        [TestMethod]
        public void SortsAsExpected()
        {
            var time1 = new TimeSpanWithType() { Type = "xyz", Time = TimeSpan.FromHours(1) };
            var time2 = new TimeSpanWithType() { Type = "auto", Time = TimeSpan.FromHours(3) };
            var time3 = new TimeSpanWithType() { Type = "auto", Time = TimeSpan.FromHours(2) };
            var sorted = new TimeSpanWithType[] { time1, time2, time3 }
                .OrderBy(t => t, TimeSpanWithTypeComparison.AutoFirst).ToArray();
            Assert.AreEqual(sorted[0], time3);
            Assert.AreEqual(sorted[1], time2);
            Assert.AreEqual(sorted[2], time1);
        }
    }
