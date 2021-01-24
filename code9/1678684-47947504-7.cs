    [TestMethod]
    [TestCategory("SeriesRepository")]
    public async Task GetSeriesAsyncShouldReturnSeriesId12345() {
        var repositoryMock = new Mock<ISeriesRepository>();
        var seriesId = "12345";
        var channel = 75864;            
        var mockSeries = new Mock<ISeries>();
        mockSeries.Setup(_ => _.SeriesId).Returns(seriesId);
        repositoryMock
            .Setup(_ => _.GetSeriesAsync(seriesId, channel))
            .ReturnsAsync(mockSeries.Object);
        var result = await repositoryMock.Object.GetSeriesAsync(seriesId, channel);
        result.SeriesId.Should().Be(seriesId);
    }
