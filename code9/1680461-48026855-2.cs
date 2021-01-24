    [TestCategory("UnitTest")]
    [TestMethod]
    public void SearchTest()
    {
        //Arrange
        var expectedResponse = new DocumentSearchResult<Models.CustomSearchResult> {  Count = 1, Results = <instantiate your custom model here>, Facets = < instantiate your custom model here > };
            
        var searchIndexClient = new Mock<ICustomSearchIndexClient>();
        searchIndexClient.Setup(r => r.Search<Models.CustomSearchResult>(It.IsAny<string>(), null)).Returns(expectedResponse);
        var business = new CustomSearchService("serviceName", "apiKey", "indexname", searchIndexClient.Object);
        //Act
        var result = business.Search("search term");
        //Assert
        Assert.IsNotNull(result, "Business logic method returned NULL");
    }
