    public class Network
    {
        static Network _instance;
    
        public static Network Instance
        {
             get { return _instance ?? (_instance = new Network()); }
        }
    
        string _networkString;
    
        private Network() { _networkString = string.Empty; }
    
        public string GetMyNetwork()
        {
            if(string.IsNullOrEmpty(_networkString))
                return (_networkString = MyProxy.Instance.GetNetworkConfig());
     
            return _networkString;
        }
    }
