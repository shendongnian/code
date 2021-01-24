    public class ExternalWsClientFactory : IExternalWsClientFactory {
        public IServiceClient ServiceClient() 
            var wsClient = new ServiceClient();
            return wsClient;
        }
    }
