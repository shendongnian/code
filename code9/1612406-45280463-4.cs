    [TestMethod]
    public async Task Version_returns_value() {
        var expected = "\"Version 0.0.1\"";
        var config = new HttpConfiguration();
        var requestMessage = new HttpRequestMessage();
        requestMessage.SetConfiguration(config);
    
        var log = new CustomTraceWriter(TraceLevel.Verbose);
    
        var httpResponseMessage = VersionFunction.Run(requestMessage, null);
        var httpContent = httpResponseMessage.Content;
        var content = await httpContent.ReadAsStringAsync();
                
        content.Should().Be(expected);
    }
