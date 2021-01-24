    [TestFixture]
    public class ExecutorTest
    {
        private Executor executor;
        private Mock<IResponseProvider> responseProviderMock;
        [SetUp]
        public void Init()
        {
            // this is not a mock but the class to be tested
            executor = new Executor();
            // the external components can be mocked, though:
            responseProviderMock = new Mock<IResponseProvider>();
            // setup the mock:
            executor.ResponseProvider = responseProviderMock.Object;
            Func<string> mockResponse = () => "dummy mocked response";
            responseProviderMock.Setup(m => m.GetResponse(It.IsAny<MyQueryType>))
                .Returns(Task.FromResult(mockResponse));
        }
        [Test]
        public async Task ExecuteSuccessTest()
        {
             // Arrange
             Func<int> input = () => 42;
             // Act
             var result = executor.Execute(input);
             // Assert
             Assert.AreEqual(42, result);
             responseProviderMock.Verify(rp => rp.GetResponse(It.IsAny<MyQueryType>(), Times.Once);
        }
    }
