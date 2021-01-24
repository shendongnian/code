    class Program
    {
        static void Main(string[] args)
        {
            int x = 2;
            string st = "";
            // this invocation compiles fine
            Blah(x, st);
            // this invocation won't compile
            Blah(st, x);
        }
        [Conditional("condition")]
        public static void Blah(int x, string st) { }
        public static void Blahh(string st, int x) { }
    }
