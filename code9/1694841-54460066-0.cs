        public static IEnumerable<T> GetValues<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }
        private Dictionary<SecurityProtocolType, bool> ProcessProtocols(string address)
        {   
            var protocolResultList = new Dictionary<SecurityProtocolType, bool>();
            var defaultProtocol = ServicePointManager.SecurityProtocol;
            ServicePointManager.Expect100Continue = true;
            foreach (var protocol in GetValues<SecurityProtocolType>())
            {
                try
                {
                    ServicePointManager.SecurityProtocol = protocol;
                    
                    var request = WebRequest.Create(address);
                    var response = request.GetResponse();
                    protocolResultList.Add(protocol, true);
                }
                catch
                {
                    protocolResultList.Add(protocol, false);
                }
            }
            ServicePointManager.SecurityProtocol = defaultProtocol;
            return protocolResultList;
        }
