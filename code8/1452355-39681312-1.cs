    public class OwinCommunicationListener : ICommunicationListener
    {
        private readonly ServiceEventSource eventSource;
        private readonly Action<IAppBuilder> startup;
        private readonly ServiceContext serviceContext;
        private readonly string endpointName;
        private readonly string appRoot;
        private IDisposable webApp;
        private string publishAddress;
        private string listeningAddress;
        public OwinCommunicationListener(Action<IAppBuilder> startup, ServiceContext serviceContext, ServiceEventSource eventSource, string endpointName)
            : this(startup, serviceContext, eventSource, endpointName, null)
        {
        }
        public OwinCommunicationListener(Action<IAppBuilder> startup, ServiceContext serviceContext, ServiceEventSource eventSource, string endpointName, string appRoot)
        {
            if (startup == null)
            {
                throw new ArgumentNullException(nameof(startup));
            }
            if (serviceContext == null)
            {
                throw new ArgumentNullException(nameof(serviceContext));
            }
            if (endpointName == null)
            {
                throw new ArgumentNullException(nameof(endpointName));
            }
            if (eventSource == null)
            {
                throw new ArgumentNullException(nameof(eventSource));
            }
            this.startup = startup;
            this.serviceContext = serviceContext;
            this.endpointName = endpointName;
            this.eventSource = eventSource;
            this.appRoot = appRoot;
        }
        public Task<string> OpenAsync(CancellationToken cancellationToken)
        {
            var serviceEndpoint = this.serviceContext.CodePackageActivationContext.GetEndpoint(this.endpointName);
            var protocol = serviceEndpoint.Protocol;
            int port = serviceEndpoint.Port;
            if (this.serviceContext is StatefulServiceContext)
            {
                StatefulServiceContext statefulServiceContext = (StatefulServiceContext) serviceContext;
                listeningAddress = string.Format(
                    CultureInfo.InvariantCulture,
                    "{0}://+:{1}/{2}{3}/{4}/{5}",
                    protocol,
                    port,
                    string.IsNullOrWhiteSpace(appRoot)
                        ? string.Empty
                        : appRoot.TrimEnd('/') + '/',
                    statefulServiceContext.PartitionId,
                    statefulServiceContext.ReplicaId,
                    Guid.NewGuid());
            }
            else if (serviceContext is StatelessServiceContext)
            {
                listeningAddress = string.Format(
                    CultureInfo.InvariantCulture,
                    "{0}://+:{1}/{2}",
                    protocol,
                    port,
                    string.IsNullOrWhiteSpace(appRoot)
                        ? string.Empty
                        : appRoot.TrimEnd('/') + '/');
            }
            else
            {
                throw new InvalidOperationException();
            }
            publishAddress = listeningAddress.Replace("+", FabricRuntime.GetNodeContext().IPAddressOrFQDN);
            try
            {
                eventSource.Message("Starting web server on " + listeningAddress);
                webApp = WebApp.Start(listeningAddress, appBuilder => startup.Invoke(appBuilder));
                eventSource.Message("Listening on " + this.publishAddress);
                return Task.FromResult(this.publishAddress);
            }
            catch (Exception ex)
            {
                eventSource.Message("Web server failed to open endpoint {0}. {1}", this.endpointName, ex.ToString());
                StopWebServer();
                throw;
            }
        }
        public Task CloseAsync(CancellationToken cancellationToken)
        {
            this.eventSource.Message("Closing web server on endpoint {0}", this.endpointName);
            this.StopWebServer();
            return Task.FromResult(true);
        }
        public void Abort()
        {
            this.eventSource.Message("Aborting web server on endpoint {0}", this.endpointName);
            this.StopWebServer();
        }
        private void StopWebServer()
        {
            if (this.webApp != null)
            {
                try
                {
                    this.webApp.Dispose();
                }
                catch (ObjectDisposedException)
                {
                    // no-op
                }
            }
        }
    }
