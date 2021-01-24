    [Fact]
    public void PassingNullConsoleWriter_ThrowsArgumentNullException()
    {
        var exception = Record.Exception(() => new UsagePrinter(null));
        Assert.IsType<ArgumentNullException>(exception);
    }
