    public void MyTest() 
    {
        var factoryMock = MockRepository.GeneratePartialMock<ApiClientFactory>();
        factoryMock.Expect(x => x.Authenticate(...).Return(...);
        var client  = factoryMock.GetApiClient();
        Assert.That(client.xxx, Is.EqualTo(...));
    }
