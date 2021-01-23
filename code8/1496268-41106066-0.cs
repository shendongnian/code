    [TestCase("test")]
    [TestCase("")]
    public void ParseResponse_InvalidResponse_ReturnsBusException(string responseMessage)
    {
        IResponseParser responseParser = new ResponseParser();           
        Assert.That(() => responseParser.parseHtmlResponse(responseMessage), 
              Throws.Exception.TypeOf<WebApiBusinessException>()
                  .And.Property("ErrorCode").EqualTo("3"));
    }
