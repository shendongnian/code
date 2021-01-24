    [TestMethod]
    [TestCategory("SeriesRepository")]
    public async Task TargetMethodShouldReturnSeriesId12345() {
        //Assert
        var repositoryMock = new Mock<ISeriesRepository>();
        var seriesId = "12345";
        var channel = 75864;            
        var mockSeries = new Mock<ISeries>();
        mockSeries.Setup(_ => _.SeriesId).Returns(seriesId);
        repositoryMock
            .Setup(_ => _.GetSeriesAsync(seriesId, channel))
            .ReturnsAsync(mockSeries.Object);
        var target = new TargetClass(repositoryMock.Object);
        //Act
        var result = await target.TargetMethod(seriesId, channel);
        //Assert
        result.Should().NotBeNull();
        result.SeriesId.Should().Be(seriesId);
    }
