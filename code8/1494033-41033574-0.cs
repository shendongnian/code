    public class ParentSystemInfo
    {
        private  string _Version = "R8.1";
        public SystemInfo()
        {
            this.Version = _Version;
        }
  
        // Setting the JsonProperty to be -1 will ensure it appears before
        // all properties for which this attribute was not set.
        [JsonProperty(Order = -1)]
        public string Version {
            get { return _Version; }
            set { _Version = value; }
        }    
    }
