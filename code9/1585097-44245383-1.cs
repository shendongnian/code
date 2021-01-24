    [JsonConverter(typeof(NameValueConverter))]   
    class Request
    {
        public Guid ActivityId { get; set; }
        public string Address1 {get; set; }
    }
