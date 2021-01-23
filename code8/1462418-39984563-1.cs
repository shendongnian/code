        class Program
        {
            static void Main(string[] args)
            {
                var map =
                    new StringToTypeMap
                    {
                        default(Foo),
                        default(Bar),
                        default(Baz)
                    };
                foreach (var key in map.Keys)
                {
                    Console.WriteLine("{0} : {1}", key, (object)map[key] ?? "(null)");
                }
                Console.ReadKey();
            }
        }
