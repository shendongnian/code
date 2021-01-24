        public class MyClass
        {
            public string name { get; set; }
        }
        var converted = JsonConvert.DeserializeObject<MyClass>(Json);
