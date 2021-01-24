    public interface ISample {
        Task DoStuff(string name);
    }
    [Test]
    public async Task SampleTest()
    {
        var sample = Substitute.For<ISample>();
        sample.DoStuff("test").Returns(x => { throw new Exception("doh"); });
        // ...
    }
