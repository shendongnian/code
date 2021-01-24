    public class SubscriptionCredentialsAdapter : SubscriptionCloudCredentials
    {
        ServiceClientCredentials _credentials;
        string _subscriptionId;
     
        public SubscriptionCredentialsAdapter(ServiceClientCredentials wrapped, string subscriptionId)
        {
            _credentials = wrapped;
            _subscriptionId = subscriptionId;
        }
        
        public override string SubscriptionId
        {
            get { return _subscriptionId; }
        }
     
        public override Task ProcessHttpRequestAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
           return _credentials.ProcessHttpRequestAsync(request, cancellationToken);
        }
    }
