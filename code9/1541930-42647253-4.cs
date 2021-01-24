    public static IRestClient MockRestClient<T>(HttpStatusCode httpStatusCode, string json) {
        var data = JsonConvert.DeserializeObject<T>(json)
        var response =  new Mock<IRestResponse<T>>();
        response.Setup(_ => _.StatusCode).Returns(httpStatusCode);
        response.Setup(_ => _.Data).Returns(data);
        var mockIRestClient = new Mock<IRestClient>();
        mockIRestClient
          .Setup(x => x.Execute<T>(It.IsAny<IRestRequest>()))
          .ReturnsAsync(response.Object);
        return mockIRestClient.Object;
    }
