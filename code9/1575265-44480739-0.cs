    using System;
    
    namespace SandboxConsole
    {
        class Program
        {
            private int _test;
            static void Main(string[] args)
            {
                var rnd = new Random();
                while (true)
                {
                    var obj = new Program();
                    obj._test = rnd.Next();
                    Console.WriteLine(obj);
                }
            }
    
            public override string ToString()
            {
                return _test.ToString();
            }
        }
    }
