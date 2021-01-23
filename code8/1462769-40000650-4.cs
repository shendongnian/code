    [TestMethod]
    public async Task GetCart() {
        //Arrange
        //...other code omitted for brevity
        var custId = Guid.Parse("9efa5332-85dc-4a49-b7af-8807742244f1");
       // Act
        var actionResult = await controller.GetCartAsync(custId);
        var contentResult = actionResult as OkNegotiatedContentResult<CartReturnModel>;
        // Assert
        Assert.IsNotNull(contentResult);
        Assert.IsNotNull(contentResult.Content);
        Assert.AreEqual(1, contentResult.Content.ItemCount);
    }
