    [TestFixture]
    public class TestClass
    {
        int NumberOfDecimalDigits(double d)
        {
            var text = Math.Abs(d).ToString();
            int integerPlaces = text.IndexOf('.');
            int decimalPlaces = text.Length - integerPlaces - 1;
            return decimalPlaces;
        }
        double GetDelta(int numberOfDecimalDigits)
        {
            var deltaStringBuilder = new StringBuilder();
            deltaStringBuilder.Append("1");
            for (int i = 0; i < numberOfDecimalDigits; i++)
            {
                deltaStringBuilder.Append("0");
            }
            double delta = 1 / double.Parse(deltaStringBuilder.ToString());
            return delta;
        }
    double Round(double value, int digits)
            {
                if (value > 0)
                {
                    return Math.Round(value, digits, MidpointRounding.AwayFromZero);
                }
                if (value < 0)
                {
                    var numberOfDecimalDigits = NumberOfDecimalDigits(value);
                    double delta = GetDelta(numberOfDecimalDigits);
                    return Math.Round(value + delta, digits, MidpointRounding.AwayFromZero);
                }
    
                return value;
            }
        double Round(double value)
        {
            if (value > 0)
            {
                return Math.Round(value, MidpointRounding.AwayFromZero);
            }
            if (value < 0)
            {
                var numberOfDecimalDigits = NumberOfDecimalDigits(value);
                double delta = GetDelta(numberOfDecimalDigits);
                return Math.Round(value + delta, MidpointRounding.AwayFromZero);
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
            Assert.AreEqual(Round(-1.55), -2);
            Assert.AreEqual(Round(-1.6666), -2);
            Assert.AreEqual(Round(-0.9999999), -1);
            Assert.AreEqual(Round(-0.001), 0);
            Assert.AreEqual(Round(2.35, 1), 2.4);
            Assert.AreEqual(Round(-2.35, 1), -2.3);
        }
