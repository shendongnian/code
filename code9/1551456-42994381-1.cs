    static void Main(string[] args)
    {
        var myJsonInput = new MyClass {Id = 123, Name ="abc"}; //Example only, any json.
        var jsonSerializerSettings = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };
    
        var myJsonOutput = JsonConvert.SerializeObject(myJsonInput, Formatting.Indented, jsonSerializerSettings);
    
        Console.Write(myJsonOutput);
        Console.ReadKey();
    }
    
    private class MyClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
