    [Test]
    public async Task Should_Return_No_Content_If_Customer_Entities_Are_Not_Found() {
        const CustomerNumber customerNumber = "WP0000000000";
        var customerEntitiesStub = new List<CustomerEntity>();
        A.CallTo(() => _tableStorageServiceDummy.GetCustomerEntities(customerNumber)).Returns(customerEntitiesStub);
        var result = await _companyController.Get(customerNumber);
        ((ResponseMessageResult)result).Response.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
