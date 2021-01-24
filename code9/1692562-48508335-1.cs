    class GreetableWrapper : IGreetable
    {
        private dynamic _wrapped;
        public GreetableWrapper(dynamic wrapped)
        {
            _wrapped = wrapped;
        }
        public string Greet()
        {
            return _wrapped.Greet();
        }
    }
    static void PrintGreeting(IGreetable g) => Console.WriteLine(g.Greet());
    static void Main(string[] args)
    {
        PrintGreeting(new GreetableWrapper(new Person()));
        Console.ReadLine();
    }
