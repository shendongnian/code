    public abstract class SomeFancyClass
    {
        protected string name;
        protected string server;
        protected abstract string implementer { get; }
        public string Generate()
        {
            if (name == "something")
                HandleGlobally(name);
            else
                HandleSpecifically(name);
        }
        public void HandleGlobally(string server)
        {
            // code
        }
        public abstract void HandleSpecifically(string server);
    }
