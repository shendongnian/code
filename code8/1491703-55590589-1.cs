    [Test]
    public void Should_deny_request()
    {
        // Given
        var resourceExecutingContext = new ResourceExecutingContext(_actionContext, new List<IFilterMetadata>(), new List<IValueProviderFactory>());
        var attribute = new YourAttribute();
        // When
        attribute.OnResourceExecuting(resourceExecutingContext);
        var result = (ContentResult) resourceExecutingContext.Result;
        // Then
        Assert.IsTrue(Equals("403", result.StatusCode.ToString()));
    }
