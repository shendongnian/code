    using System;
    
    namespace EventResolver
    {
        interface IEvent
        {
            void DoWork();
        }
        
        interface I1 : IEvent { }
    
        interface I2 : IEvent { }
    
        class Event1 : I1
        {
            public void DoWork() { Console.WriteLine(this.GetType()); }
        }
    
        class Event2 : I2
        {
            public void DoWork() { Console.WriteLine(this.GetType()); }
        }
    
        class Resolver
        {
            public void Resolve(IEvent theEvent)
            {
                theEvent.DoWork();
            }
        }
    }
