    public class SomeStuff 
    {
        public IHttpClient Client { get; }
        public SomeStuff(IHttpClient client) 
        {
            Client = client;
        }
    }
