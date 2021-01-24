    [Fact]
    public async Task MetricExistsTest()
    {
        // Arrange ...
        // Act
        var result = await _controller.Metric(Metrics.CpuLoad.ToString(), "source-1");
        // Assert
        var viewResult = Assert.IsType<ViewResult>(result);
        Assert.Equal(HttpStatusCode.OK.AsInt(), result.StatusCode.Value);
        var model = Assert.IsAssignableFrom<Metric>(
            viewResult.ViewData.Model
        );
    }
