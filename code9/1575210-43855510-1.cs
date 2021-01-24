    [TestClass]
    public class DetermineRangeFromLastFourCharacters
    {
        [TestMethod]
        public void ReturnsExpectedRangeOfStrings()
        {
            var result = new StringRangeCreator().CreateStringRange("abc", 1, 10).ToList();
            Assert.AreEqual(10, result.Count);
            Assert.AreEqual("abc1", result[0]);
            Assert.AreEqual("abc10", result[9]);
        }
    }
