    public interface IWeb
    {
        User CurrentUser { get; }
    }
    public class WebAdapter : IWeb
    {
        private readonly Web _wrappedClient;
        public WebAdapter(Web client)
        {
            _wrappedClient = client;
        }
        public User CurrentUser => _wrappedClient.CurrentUser;
    }
