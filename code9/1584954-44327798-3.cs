    class HttpCommunicationListener : ICommunicationListener
        {
            ...
    
            public Task<string> OpenAsync(CancellationToken cancellationToken)
            {
                EndpointResourceDescription endpoint =
                    serviceContext.CodePackageActivationContext.GetEndpoint("WebEndpoint");
    
                string uriPrefix = $"{endpoint.Protocol}://+:{endpoint.Port}/myapp/";
    
                this.httpListener = new HttpListener();
                this.httpListener.Prefixes.Add(uriPrefix);
                this.httpListener.Start();
    
                string publishUri = uriPrefix.Replace("+", FabricRuntime.GetNodeContext().IPAddressOrFQDN);
                return Task.FromResult(publishUri);
            }
    
            ...
        }
    
    class WebService : StatelessService
        {
            ...
    
            protected override IEnumerable<ServiceInstanceListener> CreateServiceInstanceListeners()
            {
                return new[] { new ServiceInstanceListener(context => new HttpCommunicationListener(context))};
            }
    
            ...
        }
