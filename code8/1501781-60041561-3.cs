    private SampleController _sampleController = new SampleController();
    [Theory]
    [InlineData(0, StatusCodes.Status404NotFound)]
    [InlineData(1, StatusCodes.Status415UnsupportedMediaType)]
    [InlineData(2, StatusCodes.Status200OK)]
    public async Task Foo_ResponseTest(int id, int expectedCode)
    {
        var actionResult = await _sampleController.FooAsync(id);
        var statusCodeResult = (IStatusCodeActionResult)actionResult;
        Assert.Equal(expectedCode, statusCodeResult.StatusCode);
    }
