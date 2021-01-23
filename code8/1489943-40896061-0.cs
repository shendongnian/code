        private bool _verbose = false;
        private bool _canWrite = false;
        private int _samples;
        private int x;
        private int y;
        public Foo(int samples, bool verbose, bool canWrite)
        {
            _verbose = verbose;
            _canWrite = canWrite;
            _samples = samples;
            x = 5;
            y = 5;
            RTTCalc();
        }
        public Foo() : this(0, false, false) { }
        public Foo(int samples) : this(samples, false, false) { }
        public Foo(int samples, bool verbose) : this(samples, verbose, false) { }
        private void RTTCalc()
        {
            Console.WriteLine($"V={_verbose}, S={_canWrite}");
            Console.ReadKey();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Foo test1 = new Foo(1, true, false);
            Foo test2 = new Foo(1, true);
            Foo test3 = new Foo();
        }
    }
