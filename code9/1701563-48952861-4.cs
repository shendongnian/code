    public MoqHttpContext CreateBaseMocks()
    {
    	// ...
    	
    	MockResponse = new Mock<HttpResponseBase>();
    	MockResponse.Setup(x => x.Write(It.IsAny<string>())).Callback<string>(s =>
    	{
    		var data = Encoding.ASCII.GetBytes(s);
    		_outputStream.Write(data, 0, data.Length);
    		_outputStream.Flush();
    		_outputStream.Position = 0;
    	});
    	
    	// ...
    }
