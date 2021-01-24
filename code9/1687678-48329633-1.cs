    [TestMethod]
    public void RedirectUriUnderTimeout()
    {
        //arrange
        var service = GetService();
        A.CallTo(() => _httpRequest.GetResponse()).ReturnsLazily(() => {
            Thread.Sleep(TimeSpan.FromSeconds(3));
            return new TestWebResponse();
        });
        A.CallTo(() => _httpRequest.GetResponseString())
            .ReturnsLazily(() => VALID_REQUEST_PAYLOAD);
        //act
        var url = service.GetFinalUrl("https://someplace.com/testurl");
        //assert
        Assert.IsNull(url);
    }
