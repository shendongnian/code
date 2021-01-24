    public class MyClass {
            public string Status { get; set; }
            public Dictionary<string, Dictionary<string, string>> Data { get; set; }
        }
       //and then
       var data = JsonConvert.DeserializeObject<MyClass>(jsonContent);
  
