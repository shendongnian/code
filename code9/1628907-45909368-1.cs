    [TestMethod]
    public async Task Create_Test() {
          //Arrange
          apiHelper.Setup(x => x.CreateClientAsync())
                   .Returns(Task.FromResult(true);
    
           // Use the Inject method that's just syntactical
          // sugar for replacing the default of one type at a time    
          IOCConfig.Container.Inject<IShopApiHelper>(() => apiHelper.Object);
    
          //Act
          var response = await testServer.HttpClient.PostAsJsonAsync("/api/clients", CreateObject());
    
          //Assert
          Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
    }
