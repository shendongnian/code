    class PersonName 
    {
        [JsonProperty(PropertyName = "pName")]
        public string Name { get; set; }
    }
    var obj = new  PersonName { Name = "Andrew" }
