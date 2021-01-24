    using static System.Console;
    class BasicClassObject
    {
        public BasicClassObject(string type) => WriteLine($"Created Object: {type}");
        string type { get; set; }
        void basicMethod()
        {
            WriteLine("Method Scope Begins");
            new BasicClassObject("Local B");
            WriteLine("Method Scope Ends");
        }
        static void Main(string[] args)
        {
            new BasicClassObject("Global");
            new BasicClassObject("Local A").basicMethod();
        }
    }
