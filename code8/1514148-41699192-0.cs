    public class Network
    {
        private const string PROXY_HOSTNAME_PARAM = "ProxyHostname";    
        private string network = String.Empty;   
        public string GetMyNetwork()
        {
            if (String.IsNullOrWhiteSpace(network))
            {
               MyProxy myprox = MyProxy.Instance;
               network = myprox .GetNetworkConfig(); 
            }
            return network;
        }
    }
Make sure to maintain only one instance of Network class. Each time you create a new instance of Network class, the internal network variable will be a blank string, so calling GetMyNetwork method will again call the WCF service.
