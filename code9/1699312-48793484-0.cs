    class Person
    {
       [JsonProperty(Required = Required.Always)]
       public string Name { get; set; }
       [JsonProperty(Required = Required.Always)]
       public int Age{ get; set; }
    } 
