    public OperationResult Update(MyThing thing)
    {
         return new OperationResult
                {
                   Errors = thing.ApplyEvent(Event.NullCheck)
                                 .ApplyEvent(Event.OriginalNullCheck)
                                 .ApplyEvent(Event.OriginalPropertyDiffersCheck)
                                 .CollectInfo(),
                   Success = true
                };
    }
    public class MyThing
    {
       private List<string> _errors = new List<string>();
       private MyThing _original;
       public MyThingState ThingState {get;set;}
       public MyThing ApplyEvent(Event eventInfo)
       {
           MyThingState.ApplyEvent(this, eventInfo)
       }        
    }
    
    public class NullState : MyThingState
    {
        public MyThing ApplyEvent(MyThing myThing, Event eventInfo)
        { 
             if(mything == null)
             {
               // use null object pattern
               _errors.Add("Null value")
             }
        }
    }
    public class OriginalNullState : MyThingState
    {
          public void ApplyEvent(MyThing myThing, Event eventInfo)
          {
               // Get original from database or repository
               // Save and validate null 
               // Store relevant information in _errors;
          }
    }
