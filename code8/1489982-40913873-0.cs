    async Task Testing()
    {
        await Task.Delay(100);
        this.notifyCount.Should().Be(1);
        this.simpleNotify.ShouldRaisePropertyChangeFor(x => x.Count);
    }
    [TestMethod]
    public async Task TestMethod1()
    {
        await Testing();
    }
