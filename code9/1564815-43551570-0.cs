    public partial class MyClient : ServiceClient<IMyClient>, IMyClient
    {
    
        public MyClient(Uri baseUri, ServiceClientCredentials credentials, HttpClient client) : base(client)
        {
            if (baseUri == null)
            {
                throw new ArgumentNullException("baseUri");
            }
            if (credentials == null)
            {
                throw new ArgumentNullException("credentials");
            }
    
            this.Initialize();
            this.Credentials = credentials;
            Credentials?.InitializeServiceClient(this);
            this.BaseUri = baseUri;
    
        }
        [...]
    }
