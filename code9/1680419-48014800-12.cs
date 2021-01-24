    public class Website
    {
        public string Site { get; set; }
        public string Proxy { get; set; }
        public int Port {
            get {
                string[] proxySplit = proxy.Split(':');
                int portNo = 0;
                if (proxySplit.Length == 2) {
                    Int32.TryParse(proxySplit[1], out portNo);
                }
                return portNo;
            }
        }
    }
