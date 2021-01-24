    [TestFixture]
        public class TestClass
        {
            double Round(double value)
            {
                if (value > 0)
                {
                    return Math.Round(value, MidpointRounding.AwayFromZero);
                }
                if (value < 0)
                {
                    return Math.Round(value + 0.1, MidpointRounding.AwayFromZero);
                }
    
                return value;
            }
            [Test]
            public void TestMethod()
            {
                Assert.AreEqual(Round(1), 1);
                Assert.AreEqual(Round(1.9), 2);
                Assert.AreEqual(Round(1.5), 2);
                Assert.AreEqual(Round(2.5), 3);
    
                Assert.AreEqual(Round(-1), -1);
                Assert.AreEqual(Round(-2.9), -3);
    
                Assert.AreEqual(Round(-1.5), -1);
                Assert.AreEqual(Round(-2.5), -2);
                Assert.AreEqual(Round(1.4), 1);
                Assert.AreEqual(Round(1.6), 2);
    
                Assert.AreEqual(Round(-1.4), -1);
                Assert.AreEqual(Round(-1.6), -2);
    
    
                Assert.AreEqual(Round(-1.6666), -2);
                Assert.AreEqual(Round(-0.9999999), -1);
                Assert.AreEqual(Round(-0.001), 0);
    
            }
        }
