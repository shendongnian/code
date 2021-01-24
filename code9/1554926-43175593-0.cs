    [Fact]
    public async Task GivenSomeValidHttpRequests_GetSomeDataAsync_ReturnsAFoo()
    {
        // Arrange.
    
        // Fake response.
        const string responseData = "{ \"Id\":69, \"Name\":\"Jane\" }";
        var messageResponse = FakeHttpMessageHandler.GetStringHttpResponseMessage(responseData);
    
        // Prepare our 'options' with all of the above fake stuff.
        var options = new HttpMessageOptions
        {
            RequestUri = MyService.GetFooEndPoint,
            HttpResponseMessage = messageResponse
        };
    
        // 3. Use the fake response if that url is attempted.
        var messageHandler = new FakeHttpMessageHandler(options);
    
        var myService = new MyService(messageHandler);
    
        // Act.
        // NOTE: network traffic will not leave your computer because you've faked the response, above.
        var result = await myService.GetSomeFooDataAsync();
    
        // Assert.
        result.Id.ShouldBe(69); // Returned from GetSomeFooDataAsync.
        result.Baa.ShouldBeNull();
        options.NumberOfTimesCalled.ShouldBe(1);
    }
