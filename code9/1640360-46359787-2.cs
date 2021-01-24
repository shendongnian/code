    public static class Events
    {
        public static event EventHandler OnInvoke;
        public static void Run()
        {
            OnInvoke?.Invoke(null, EventArgs.Empty);
        }
    }
