    var t = deserializeXMLtoClass<list_bulk_response>(xmlstring);
----
    public class list_bulk_response
    {
        public string status_code { get; set; }
        public string status_text { get; set; }
        public list_request list_request { get; set; }
    }
    public class list_request
    {
        [XmlElement("request_bulk")]
        public List<request_bulk> request_bulk { get; set; }
    }
    public class request_bulk
    {
        public string request_status_code { get; set; }
        public string request_status_text { get; set; }
        public string id { get; set; }
    }
