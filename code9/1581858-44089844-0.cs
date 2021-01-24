    public class Rootobject
    {
        [JsonProperty("a-string")]
        public string astring { get; set; }
        [JsonProperty("another-string")]
        public string anotherstring { get; set; }
        public string another { get; set; }
    }
    public class Program
    {
        public static void Main()
        {
            var root = new Rootobject { another = "1", anotherstring = "hello", astring = "123" };
            string json = JsonConvert.SerializeObject(root);
            Console.Read();
        }
    }
