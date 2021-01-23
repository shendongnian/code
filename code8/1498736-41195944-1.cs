    public class Program
    {
        public static void Main(string[] args)
        {
            TestClass tc = new TestClass
            {
                PropertyName = "foo",
                AnotherPropertyName = "bar"
            };
            Console.WriteLine("--- Serialize ---");
            string json = JsonConvert.SerializeObject(tc, Formatting.Indented);
            Console.WriteLine(json);
            Console.WriteLine();
            Console.WriteLine("--- Deserialize ---");
            TestClass test = JsonConvert.DeserializeObject<TestClass>(json);
            Console.WriteLine("PropertyName: " + test.PropertyName);
            Console.WriteLine("AnotherPropertyName: " + test.AnotherPropertyName);
        }
    }
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class TestClass
    {
        public string PropertyName { get; set; }
        public string AnotherPropertyName { get; set; }
    }
