    public interface IRepository {
        Task<int> FindId(string name);
    }
    [Test]
    public async Task SampleTest2()
    {
        var sample = Substitute.For<IRepository>();
        sample.FindId("test").Returns<int>(x => { throw new Exception("doh"); });
        // ...
    }
