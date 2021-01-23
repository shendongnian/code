    [Theory]
    public async Task GivenResultAlreadyRetrieved_ShouldNotCallServiceAgain()
    {
        // Arrange
        var expected = new MyViewModel();
        object actualOut;
    
        var cache = new MemoryCache(new MemoryCacheOptions());
        var searchService = new Mock<ISearchService>();
    
        var input = new SearchRequestViewModel();
    
        searchService
            .SetupSequence(s => s.FindAsync(It.IsAny<SearchRequestViewModel>()))
            .Returns(Task.FromResult(expected))
            .Returns(Task.FromResult(new MyViewModel()));
    
        var sut = new MyController(cache, searchService.Object);
    
        // Act
        var resultFromFirstCall = await sut.Search(input);
        var resultFromSecondCall = await sut.Search(input);
    
        // Assert
        Assert.Same(expected, resultFromFirstCall);
        Assert.Same(expected, resultFromSecondCall);
    }
