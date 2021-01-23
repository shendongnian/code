    public class Network
    {
        private const string PROXY_HOSTNAME_PARAM = "ProxyHostname";    
        private string network = String.Empty;  
        private Network _instance; 
        public string GetMyNetwork()
        {
            if (String.IsNullOrWhiteSpace(network))
            {
               MyProxy myprox = MyProxy.Instance;
               network = myprox .GetNetworkConfig(); 
            }
            return network;
        }
        private Network() { }
        public Network Instance
        {
           get
           {
              if (this._instance == null)
              {
                  this._instance = new Network();
              }
              return this._instance;
           }
        }     
    }
Make sure to maintain only one instance of Network class. Each time you create a new instance of Network class, the internal network variable will be a blank string, so calling GetMyNetwork method will again call the WCF service.
