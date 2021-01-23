    public class GenericEvent
    {
        // Here I have an event.
        protected void RaiseEvent();
    }
    
    public class LibClass1 : GenericEvent 
    {
        public voidDoSomethingAndRaiseEvent()
        {
            // ...
            RaiseEvent();
        }
    }
