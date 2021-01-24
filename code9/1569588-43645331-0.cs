    namespace ConsoleApplication1
    {
        public class Program
        {
            private static void Main(string[] args)
            {
                var dic = new Dictionary<string, object>
                {
                    { "One", "1" }, { "Two", 2 },
                    { "Three", 3.0 }, { "Four", new Person() },
                    { "Five", new SimplePerson() },
    
                };
                foreach (var thisItem in dic)
                {
                    // thisItem.Value will show "1", 2, 3, "Test" 
                    // and ConsoleApplication1.SimplePerson
                    Console.WriteLine($"{ thisItem.Key } : { thisItem.Value }");
                }
    
                var obj = JsonConvert.SerializeObject(dic);
            }
        }
    
        public class SimplePerson
        {
    
        }
        public class Person
        {
            public override string ToString()
            {
                return "Test";
            }
        }
    }
