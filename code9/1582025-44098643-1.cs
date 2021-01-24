    [TestClass]
    public class UnknownSubstringFinderTests
    {
        [TestMethod]
        public void FindsSubstringsCommonToEachInputString()
        {
            var subject = new UnknownSubstringFinder();
            var input = new string[]{"FooOne","FooTwo","FooThree"}
            var output = subject.FindCommonSubstrings(input).ToList();
            assert.IsTrue(output.Contains("Foo"));
        }
    }
