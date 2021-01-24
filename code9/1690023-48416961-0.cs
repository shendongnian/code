    public class MyClass
    {
        private event Action Event;
    
        public void RegisterHandlers()
        {
            Event += FuncA;
            Event += FuncB;
    
            Event();
        }
    
        public void HandleCommand()
        {
            this.Event();
        }
    
        private void FuncA() { /*...*/ }
        private void FuncB() { /*...*/ }
    }
