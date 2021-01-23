    [Fact]
    public void GetOrders_WithOrdersInRepo_ReturnsOk() {
        // arrange
        var controller = new OrdersController(new MockRepository());
        // act
        var result = controller.GetOrders();
        var okResult = result as OkObjectResult;
        // assert
        Assert.IsNotNull(okResult);
        Assert.Equal(200, okResult.StatusCode);
    }
