    class URLClass
    {
        public URLClass()
        {
    
        }
    
        //packet count
        private int pktCount;
        public int PktCount
        {
            get { return pktCount; }
            set { pktCount = value; }
        }
    
        //URL accessed
        private string uRLString;
        public string URLString
        {
            get { return uRLString; }
            set { uRLString = value; }
        }}
    
        public bool StartsWith(string match)
        {
            return uRLString.StartsWith(match);
        }
