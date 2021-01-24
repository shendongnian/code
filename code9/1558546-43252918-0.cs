    [Fact]
    public async Task TestHttpExceptionOnBadRequest() {
    
        var xmlSerializer = new Mock<IXmlSerializer>();
        xmlSerializer
            .Setup(serializer => serializer.Deserialize(It.IsAny<Stream>()))
            .Returns(new PostcodeContainer());
    
        var expectedResponse = new HttpResponseMessage(HttpStatusCode.BadRequest);
        var httpClient = new Mock<IHttpHandler>();
        httpClient
            .Setup(client => client.GetAsync(It.IsAny<string>()))
            .ReturnsAsync(expectedResponse);
    
        var postcodeLookup = new PostcodeLookupService(xmlSerializer.Object, httpClient.Object, "", "");
        await Assert.ThrowsAsync<HttpRequestException>(async () => await postcodeLookup.SearchAsync("", ""));
    }
 
