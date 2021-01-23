    //...other code removed for brevity
    var contentResult = actionResult as NegotiatedContentResult<string>;
    // Then: 
    Assert.IsNotNull(contentResult);
    Assert.AreEqual(HttpStatusCode.NotFound, contentResult.StatusCode);
