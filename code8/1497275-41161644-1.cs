    public interface IClientContext
    {
        IWeb Web { get; }
        void Load<T>(T clientObject, params Expression<Func<T, object>>[] retrievals) where T : ClientObject;
        void ExecuteQuery();
    }
    public class ClientContextAdapter : IClientContext
    {
        private readonly ClientContext _wrappedClient;
        public ClientContextAdapter(ClientContext client)
        {
            _wrappedClient = client;
        }
        public IWeb Web => new WebAdapter(_wrappedClient.Web);
        public void Load<T>(T clientObject, params Expression<Func<T, object>>[] retrievals) where T : ClientObject
        {
            _wrappedClient.Load(clientObject, retrievals);
        }
        public void ExecuteQuery()
        {
            _wrappedClient.ExecuteQuery();
        }
    }
