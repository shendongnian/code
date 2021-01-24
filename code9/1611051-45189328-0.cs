    static void Main()
    {
        // This is your composition root
        var numberProvider = new NumberProvider();
        var b = new B(numberProvider);
        b.DoSomething();
    }
    
    class NumberProvider
    {
        private int _number = 0;
    
        // In the real world, maybe this gets a value from a web service
        // and implements an INumberProvider interface so you can mock it
        // for unit testing
        public int GetNumber() => _number++;
    }
    
    class B
    {
        private readonly NumberProvider _numberProvider;
    
        public B(NumberProvider numberProvider)
        {
            _numberProvider = numberProvider;
        }
    
        public void DoSomething()
        {
            Console.WriteLine(_numberProvider.GetNumber());
        }
    }
