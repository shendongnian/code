    public class Client
    {
        public string __entityName__ { get; set; }
        public Dictionary<string, string> ClientId { get; set; }
        public Dictionary<string, string> GivenName { get; set; }
    }
    var deserializedWithClass = JsonConvert.DeserializeObject<Dictionary<string, Client>>(json);
