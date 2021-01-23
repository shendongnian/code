    [TestMethod]
    public async Task GetCart() {
        //Arrange
        //...other code omitted for brevity
        var username = "m";
        var customerGuid = "9efa5332-85dc-4a49-b7af-8807742244f1"; 
        var account = new UserAccount { UserName = username, Email = "m@m.com" };
        var mockAppManager = new Mock<ApplicationUserManager>();
        mockAppManager.Setup(c => c.FindByNameAsync(username)).ReturnsAsync(account);
        var mockRepository = new Mock<jCtrl.Services.IUnitOfWork>();
        mockRepository.Setup(x => x.CartItems.GetCustomerCart(It.IsAny<Customer>(), It.IsAny<bool>())).ReturnsAsync(cart.AsEnumerable());
        var requestUri = new Uri(string.Format("http://localhost/customers/{0}/carts", customerGuid));
        var controller = new CartsController(mockRepository.Object){
            Request = new HttpRequestMessage {RequestUri = requestUri},
            Configuration = new HttpConfiguration(),
            User = new ClaimsPrincipal(new GenericIdentity(username))
        };
        var custId = Guid.Parse(customerGuid);
       // Act
        var actionResult = await controller.GetCartAsync(custId);
        var contentResult = actionResult as OkNegotiatedContentResult<CartReturnModel>;
        // Assert
        Assert.IsNotNull(contentResult);
        Assert.IsNotNull(contentResult.Content);
        Assert.AreEqual(1, contentResult.Content.ItemCount);
    }
