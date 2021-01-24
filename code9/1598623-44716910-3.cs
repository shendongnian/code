    public async Task _SendRequestAsync_Test() {
        //Arrange           
        var handlerStub = new DelegatingHandlerStub();
        var client = new HttpClient(handlerStub);
        var sut = new ClassA(client);
        var obj = new SomeObject() {
            //Populate
        };
        //Act
        var response = await sut.SendRequest(obj);
        //Assert
        Assert.IsNotNull(response);
        Assert.IsTrue(response.IsSuccessStatusCode);
    }
