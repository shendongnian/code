    [Theory]
    [InlineData(4, 2, 3, 4)]
    [InlineData(4, 2, 5, 5)]
    [InlineData(4, 2, 4, 4)]
    [InlineData(2, 4, 3, 4)]
    [InlineData(2, 2, 3, 3)]
    [InlineData(2, 4, 5, 5)]
    [InlineData(2, 4, 4, 4)]
    public void Max_ReturnsExpectedValue(int a, int b, int c, int expectedMax)
    {
        int actualMax = Program.Max(a, b, c);
        Assert.Equal(expectedMax, actualMax);
    }
