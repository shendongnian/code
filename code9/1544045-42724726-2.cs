            public class Example
            {
                public Dictionary<string, decimal> SomeDictionary { get; set; }
                public Example()
                {
                    SomeDictionary = new Dictionary<string, decimal>();
                    string key = "key";
                    SomeDictionary[key] = 10.0M;
                }
            }
            static void Main(string[] args)
            {
                var example = new Example();
                Console.ReadKey();
            }
