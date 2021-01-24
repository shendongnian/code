    class PersonWrapper : IGreetable
    {
        private dynamic _wrapped;
        public PersonWrapper(dynamic wrapped)
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
        PrintGreeting(new PersonWrapper(new Person()));
        Console.ReadLine();
    }
