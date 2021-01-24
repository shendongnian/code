    [TestMethod]
    public async Task _TestPostData() {
        var dictionary = new Dictionary<string, string[]>() {
             { "test", new[]{"testValue"}},
             { "test2", new[]{"testValue2"}},
        };
        String rawFormData = "test=testValue&test2=testValue2";
        var stream = new MemoryStream();
        using (var writer = new StreamWriter(stream, Encoding.UTF8, 4 * 1024, true))
            await writer.WriteAsync(rawFormData);
        stream.Seek(0, SeekOrigin.Begin);
        var formMock = new Mock<IFormCollection>();
        formMock.Setup(_ => _.GetEnumerator()).Returns(() => dictionary.GetEnumerator());
        var readableString = formMock.As<IReadableStringCollection>();
        //..setup as desired 
        var requestMock = new Mock<IOwinRequest>();
        requestMock.Setup(_ => _.Method).Returns("POST");
        requestMock.Setup(_ => _.Body).Returns(stream);
        requestMock.Setup(_ => _.ContentType).Returns("application/x-www-form-urlencoded");
        requestMock.Setup(_ => _.ReadFormAsync()).ReturnsAsync(formMock.Object);
        Assert.IsNotNull(await requestMock.Object.ReadFormAsync());
    }
