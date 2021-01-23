    void TestSetupMocks()
    {
        var request = new TestWebRequest();
        Mock<IWebRequestCreate> _webClientFactory;
        _webClientFactory.Setup(x => x.Create(uri)).Returns(request);
    }
    class TestWebRequest : WebRequest
    {
       // Implement abstract functions
    }
