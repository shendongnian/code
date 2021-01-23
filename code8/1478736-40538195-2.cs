    [TestMethod]
    public async Task TestMethod1()
    {
        var mockWait = new Mock<IAsyncDelayer>();
        mockWait.Setup(m => m.Delay(It.IsAny<TimeSpan>())).Returns(Task.FromResult(0));
        var sut = new ClassUnderTest(mockWait.Object);
        var result = await sut.MethodUnderTest();
        Assert.AreEqual(5, result);
    }
