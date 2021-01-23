    void Main()
    {
        var t = new Test { Key = 42, Value = "Meaning of life" };
        
        var json = JsonConvert.SerializeObject(
            t, Newtonsoft.Json.Formatting.Indented,
            new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
        Console.WriteLine(json);
        
        var obj  =JsonConvert.DeserializeObject(json,
            new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
        Console.WriteLine(obj.GetType().FullName);
    }
    
    public class Test
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }
