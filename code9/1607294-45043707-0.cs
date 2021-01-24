    public class ExWrapper
    {
        private readonly Action _action;
        private readonly ExWrapper _prev;
    
        private ExWrapper(Action action, ExWrapper prev = null)
        {
            _action = action;
            _prev = prev;
        }
    
        public static ExWrapper First(Action test)
        {
            return new ExWrapper(test);
        }
    
        public ExWrapper Then(Action test)
        {
            return new ExWrapper(test, this);
        }
    
        public void Execute()
        {
            if (_prev != null)
                try
                {
                    _prev.Execute();
                }
                catch (Exception)
                {
                    _action();
                }
            else
                _action();
        }
    }
