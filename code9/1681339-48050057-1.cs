    [Fact]
    public void AutoFillConfirmationDownloadInvoiceDate()
    {
        var fixture = new Fixture();
        fixture.Customize<Order>(c => c
            .Do(o => o.ConfirmDownloadInvoiceDate(fixture.Create<StubDateTimeProvider>())));
        var actual = fixture.Create<Order>();
        Assert.NotNull(actual.ConfirmationDownloadInvoiceDate);
        Assert.NotEqual(default(DateTime), actual.ConfirmationDownloadInvoiceDate);
    }
