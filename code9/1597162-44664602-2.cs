    public class ParsesStringsToIntsWithLinq
    {
        public IEnumerable<int> Parse(string input)
        {
            var i = 0;
            return (from segment in input.Split(',')
                where int.TryParse(segment, out i) 
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
    }
