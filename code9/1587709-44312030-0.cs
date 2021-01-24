    public class SelfLinkModel
    {
        public SelfLinkModel()
        {
            Headers = new string[0];
        }
        public string Uri { get; set; }
        public string Method { get; set; }
        public string[] Headers { get; set; }
    }
