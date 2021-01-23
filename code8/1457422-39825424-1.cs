    public class GenericEvent
    {
        public event EventHandler SomeEvent;
        // ...
    }
    
    public class LibClass1
    {
        private readonly GenericEvent _ge;
    
        // ...
    
        public event EventHandler SomeEvent
        {
            add { _ge.SomeEvent += value; }
            remove { _ge.SomeEvent -= value; }
        }
    
        public void DoSomethingAndRaiseEvent()
        {
            // ...
            SomeEvent?.Invoke(this, EventArgs.Emtpy);
        }
    }
