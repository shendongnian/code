    class Program
        {
            static void Main(string[] args)
            {
                var test = new TestObject
                {
                    Name = "Hello",
                    State = 7
                };
    
                var json = ConvertToJson(test);
                var stringify = Stringify(json);
    
                var result = StringifyToObject<TestObject>(stringify);
            }
    
            public static string ConvertToJson<T>(T obj)
            {
                return JsonConvert.SerializeObject(obj);
            }
    
            public static string Stringify(string json)
            {
                return JsonConvert.ToString(json);
            }
    
            public static T StringifyToObject<T>(string stringify)
            {
                var json = JsonConvert.DeserializeObject<string>(stringify);
                var result = JsonConvert.DeserializeObject<T>(json);
                return result;
            }
        }
    
        public class TestObject
        {
            public TestObject()
            {
                Name = "Hi";
                State = 0;
            }
    
            public string Name { get; set; }
            public int State { get; set; }
        }
