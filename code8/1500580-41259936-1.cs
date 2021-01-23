    public class RootObject
    {
        public Request request { get; set; }
    }
    public class Request
    {
        public Airport airport { get; set; }
    }
    public class Airport
    {
        public string requestedCode { get; set; }
        public string fsCode { get; set; }
    }
