    public class ParsesStringsToIntsWithLinq
    {
        public IEnumerable<int> Parse(string input)
        {
            var i = 0;
            return (from segment in input.Split(',')
                where int.TryParse(segment, out i) && i!=-1
                select i);
        }
    }
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void IgnoresNonIntegers()
        {
            var input = "1,2,3,4,s,6";
            var output = new ParsesStringsToIntsWithLinq().Parse(input);
            Assert.IsTrue(output.SequenceEqual(new []{1,2,3,4,6}));
        }
        [TestMethod]
        public void IgnoresNegativeOne()
        {
            var input = "-1,2,3,4,s,-2";
            var output = new ParsesStringsToIntsWithLinq().Parse(input);
            Assert.IsTrue(output.SequenceEqual(new[] { 2, 3, 4, -2 }));
        }
    }
