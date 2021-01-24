    class MyClass
    {
        public static MyClass Instance { get; private set; }
        public MyClass()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                throw new Exception("MyClass already instantiated.");
            }
        }
    }
