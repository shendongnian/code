    public class Model
    {
        public string BaseAddress { get; set; }
        public string Scheme { get { return "http://"; } }
        public string Path { get { return ":8124/api/Items"; } }
    
        public string WebServiceURL {
            get {
                return Scheme + BaseAddress + Path;
            }
        }
    }
