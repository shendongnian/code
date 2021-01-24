    using System;
        
    namespace EventREsolver
    {
        public interface IEvent { }
    
        public class Event1 : IEvent { }
    
        public class Event2 : IEvent { }
    
        public class Resolver
        {
            public void Resolve(IEvent theEvent)
            {
                switch (theEvent)
                {
                    case Event1 e1: Resolve(e1); break;
                    case Event2 e2: Resolve(e2); break;
                    default: throw new ArgumentException("not a recognized type", nameof(theEvent));
                }   
            } 
            
            private void Resolve(Event1 theEvent)
            {
                Console.WriteLine("Resolve I1");
            }
    
            private void Resolve(Event2 theEvent)
            {
                Console.WriteLine("Resolve I2");
            }
        }
    
        public class Generator
        {
            int state = 0;
    
            public IEvent Generate()
            {
                if (state == 0)
                {
                    state++;
                    return new Event1();
                }
                return new Event2();
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                var generator = new Generator();
                var event1 = generator.Generate();
                var event2 = generator.Generate();
                
                var resolver = new Resolver();
                resolver.Resolve(event1);
                resolver.Resolve(event2);
        
                Console.ReadKey();
            }
        }
    }
