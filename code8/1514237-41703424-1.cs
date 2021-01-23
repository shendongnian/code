    using System;
    using System.Collections.Generic;
    
    namespace ConsoleApplication
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                IEventHandler<SomeEvent1> handler1 = new SomeEvent1Handler();
                IEventHandler<SomeEvent2> handler2 = new SomeEvent2Handler();
    
    
                IList<IEventHandler> handlers = new List<IEventHandler>();
                
                handlers.Add(new SomeEvent1Handler());
            }
    
            public interface IEvent {
    
            }
    
            public interface IEventHandler 
            {
                void Handle(IEvent someEvent);
            }
    
            public class SomeEvent1 : IEvent {
            }
            public class SomeEvent2 : IEvent {
            }
    
            public class SomeEvent1Handler : IEventHandler
            {
                public void Handle(IEvent someEvent)
                {
                    var event = someEvent as SomeEvent1;
                    if(event == null)
                        return;
    
                    //Do stuff here.
                }
            }
    
            public class SomeEvent2Handler : IEventHandler
            {
                public void Handle(IEvent someEvent)
                {
                    var event = someEvent as SomeEvent2;
                    if(event == null)
                        return;
    
                    //Do stuff here.
                }
            }
        }
    
    }
