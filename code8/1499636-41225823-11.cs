    class Program
        {
            static void Main(string[] args)
            {
                IEnumerable<Contact> contacts = new List<Contact>()
                {
                    new Contact
                    {
                        Name = "Name1"
                    },
                    new Contact
                    {
                        Name = "Name2"
                    }
                }; //load your methods from the database or create them here
    
                var res = contacts.Generate(GenerateRandomContact, 5);
    
                Console.ReadLine();
            }
    
            static IEnumerable<Contact> GenerateRandomContact(int amount)
            {
                var random = new Random(Environment.TickCount);
    
                for (int i = 0; i < amount; i++)
                {
                    yield return new Contact
                    {
                        Name = $"Name_{random.Next()}"
                    };
                }
            }
            
        }
    
        public class Contact
        {
            public string Name { get; set; }
        }
    
        public static class Extension
        {
            public static IEnumerable<T> Generate<T>(this IEnumerable<T> elements, Func<int, IEnumerable<T>> func, int amount)
            {
                if (func != null)
                {
                    return func(amount);
                }
    
                return Enumerable.Empty<T>();
            }
        }
    }
