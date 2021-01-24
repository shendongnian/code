    var result = JsonConvert.DeserializeObject<List<MenuItem>>(json);
    class MenuItem
    {
        public long id { get; set; }
        public string item { get; set; }
        public MenuItem child { get; set; }
    }
