    [TestMethod]
    public void Test1()
    {
        string h = "{\r\n\t\"took\": 2,\r\n\t\"timed_out\": false,\r\n\t\"_shards\": {\r\n\t\t\"total\": 6,\r\n\t\t\"successful\": 6,\r\n\t\t\"failed\": 0\r\n\t},\r\n\t\"hits\": {\r\n\t\t\"total\": 0,\r\n\t\t\"max_score\": null,\r\n\t\t\"hits\": []\r\n\t}\r\n}";
        Mock<IApiCallDetails> apiCallDetails = new Mock<IApiCallDetails>(MockBehavior.Strict);
        apiCallDetails.Setup(x => x.Success).Returns(true);
        var resp = new StringResponse(h);
        resp.ApiCall = apiCallDetails.Object;
        Mock<IElasticLowLevelClient> elasticLowLevelClient = new Mock<IElasticLowLevelClient>(MockBehavior.Strict);
        elasticLowLevelClient.Setup(x => x.Search<StringResponse>(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<PostData>(), It.IsAny<SearchRequestParameters>())).Returns(resp);
    }
