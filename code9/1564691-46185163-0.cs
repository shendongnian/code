    public interface IHttpBinApi
    {
        [Headers("X-Foo: 123")]
        [Get("/headers")]
        Task<dynamic> GetHeaders([Header("X-Bar")] string bar);
    }
    // And in the consumer
    Console.WriteLine(await api.GetHeaders("bar"));
