    [Theory]
    [InlineData(0, StatusCodes.Status404NotFound)]
    [InlineData(1, StatusCodes.Status415UnsupportedMediaType)]
    [InlineData(2, StatusCodes.Status200OK)]
    public async Task Foo_ResponseTest(int id, int expectedCode)
    {
        dynamic actionResult = await new SampleController().FooAsync(id);
        Assert.Equal(expectedCode, (int)actionResult.StatusCode);
    }
