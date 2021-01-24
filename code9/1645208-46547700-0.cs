    [TestFixture("A", "1234")]
    [TestFixture("B", "ABCD")]
    public class TestCalls
    {
        private static RestApiClient client;
        private readonly string username;
        private readonly string password;
        
        public TestCalls(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
        
        [SetUp]
        public void Init()
        {
            client = new RestApiClient("http://localhost:1234/");
            SetToken(this.username, this.password);
        }
        [Test]
        public async Task ExampleTest()
        {
            // a test methods
            var value = await client.ExecuteRequestAsync(...);
            Assert.That(value, Is.Not.Null.And.Not.Empty)
            // more assertions
        }
    }
