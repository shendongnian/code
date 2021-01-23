    public class StatelessServiceBase : StatelessService
    {
        .
        .
        .
        protected ICommunicationListener CreateListener(StatelessServiceContext context, object service, string interfaceName, AuthenticationInspector inspector = null)
        {
            Uri baseUri = new Uri($"{Util.GetBaseServerAddress()}{service.GetType().Name}");
            ServiceHost serviceHost = new ServiceHost(service.GetType(), baseUri);
            this.AddServiceEndpoint(serviceHost, service, interfaceName, inspector);
            return new ServiceHostCommunicationListener(serviceHost, baseUri.AbsoluteUri);
        }
        private void AddServiceEndpoint(ServiceHost serviceHost, object service, string interfaceName, AuthenticationInspector inspector)
        {
            var binding = new WSHttpBinding(SecurityMode.None);
            binding.SendTimeout = new TimeSpan(0, 10, 0);
            binding.ReceiveTimeout = new TimeSpan(0, 10, 0);
            binding.MaxBufferPoolSize = 2147483647;
            binding.MaxReceivedMessageSize = 2147483647;
            binding.ReaderQuotas = new System.Xml.XmlDictionaryReaderQuotas
            {
                MaxDepth = 2147483647,
                MaxStringContentLength = 2147483647,
                MaxArrayLength = 2147483647,
                MaxBytesPerRead = 2147483647,
                MaxNameTableCharCount = 2147483647
            };
            if (inspector == null)
            {
                serviceHost.AddServiceEndpoint(service.GetType().GetInterface(interfaceName), binding, string.Empty);
            }
            else
            {
                serviceHost.AddServiceEndpoint(service.GetType().GetInterface(interfaceName), binding, string.Empty).Behaviors.Add(inspector);
            }
        }
    }
