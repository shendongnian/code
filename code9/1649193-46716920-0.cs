    class Data
    {
        public List<string> Metrics { get; set; }
    }
    var json = "{\"metrics\":[]}";
    var obj = JsonConvert.DeserializeObject<Data>(json);
