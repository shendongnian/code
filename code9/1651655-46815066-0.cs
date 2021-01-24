    class Program
    {
        static void Main(string[] args)
        {
    
            var json = @"{""cities"": [""London"", ""Paris"", ""New York""]}";
    
            MyObject result = JsonConvert.DeserializeObject<MyObject>(json);
    
            foreach (var city in result.Cities)
            {
                Console.WriteLine(city);
            }
    
            Console.ReadKey();
        }
    
        public class MyObject
        {
            [JsonProperty("cities")]
            public List<string> Cities { get; set; }
        }
    }
