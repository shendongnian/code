    public partial class DocumentIntegrationClient :
        System.ServiceModel.ClientBase<ServiceReference1.IDocumentIntegration>, ServiceReference1.IDocumentIntegration
    {
        public DocumentIntegrationClient(IOptions<DocumentServiceOptions> options) : base()
        {
            if(options==null)
            {
                throw new ArgumentNullException(nameof(options));
            }
            this.ClientCredentials.Username.Username = options.Username;
            this.ClientCredentials.Username.Password = options.Password;
            this.Endpoint.Address = new EndpointAddress(options.BaseUrl);
        }
    }
