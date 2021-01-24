    public class ParsesStringToIntsWithLinq
    {
        public IEnumerable<int> Parse(string commaDelimitedIntegerList)
        {
            var split = commaDelimitedIntegerList.Split(',');
            var i = 0;
            return (from segment in split where int.TryParse(segment, out i) select i);
        }
    }
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void IgnoresNonIntegers()
        {
            var input = "1,2,3,4,s,6";
            var output = new ParsesStringToIntsWithLinq().Parse(input);
            Assert.IsTrue(output.SequenceEqual(new []{1,2,3,4,6}));
        }
        [TestMethod]
        public void HandlesNegatives()
        {
            var input = "1,2,3,4,s,-2";
            var output = new ParsesStringToIntsWithLinq().Parse(input);
            Assert.IsTrue(output.SequenceEqual(new[] { 1, 2, 3, 4, -2 }));
        }
    }
