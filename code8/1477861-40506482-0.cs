    [TestFixture]
    public class ImportTests
    {
        public ImportTests()
        {
            //inititalize test case source
        }
        
        [TestFixtureSetUp]
        public void ImporTestSetup()
        {
            //inititalize rest of test
        }
        public IEnumerable<string> Fields()
        {
            return new[] { "foo", "bar", "foobar" };
        }
        [Test]
        [TestCaseSource("Fields")]
        public void PropertyTest(string info)
        {
           // Assert
        }
    }
