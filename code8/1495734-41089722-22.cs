    [Test]
    public void GetCustomerTest() {
        //Arrange
        var fakeService = new FakeService();
        var customerController = new CustomerController(fakeService) {
            Request = new HttpRequestMessage {
                Method = HttpMethod.Get,
                RequestUri = new Uri(ServiceBaseURL + "api/getcustomer")
            }
        };
        customerController.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());
        //Act    
        var _response = customerController.GetCustomer() as OkNegotiatedContentResult<IEnumerable<CustomerViewModel>>;
        //Assert
        Assert.IsNotNull(_response);
    
        var responseResult = _response.Content;
        Assert.IsNotNull(responseResult);
        Assert.AreEqual(responseResult.Any(), true);    
    }
