    public static IRestClient MockRestClient<T>(HttpStatusCode httpStatusCode, string json) {
        var data = JsonConvert.DeserializeObject<T>(json)
        var response = Mock.Of<IRestResponse>(_ => _.StatusCode == httpStatusCode && _.Data == data);
        var mockIRestClient = new Mock<IRestClient>();
        mockIRestClient
          .Setup(x => x.Execute<T>(It.IsAny<IRestRequest>()))
          .ReturnsAsync(response);
        return mockIRestClient.Object;
    }
