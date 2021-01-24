    using System;
    
    namespace EventResolver
    {
        class Program
        {
            static void Main(string[] args)
            {
                var event1 = new Event1();
                var event2 = new Event2();
    
                var resolver = new Resolver();
                resolver.Resolve(event1);
                resolver.Resolve(event2);
    
                Console.ReadKey();
            }
        }
    }
