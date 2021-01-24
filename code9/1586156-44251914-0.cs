    public class MyEventArgs : EventArgs
    {
        private readonly Action _callback { get; set;}
     
        public MyEventArgs(Action callback = null)
        {
            _callback = callback;
        }
        public void ExecuteCallback()
        {
            _callback?.Invoke();
        }
    }
