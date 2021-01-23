    private Func<YourEventArgs, Task> _callback;
    public Func<YourEventArgs, Task> Callback
    {
        set
        {
            if (value != null && value.GetInvocationList().Length > 1) {
                throw new Exception("...");
            }
            _callback = value;                
         }
     }
