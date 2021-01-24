    using System;
    public class ArgTester
    {
        static int Main(string[] args)
        {
            Console.WriteLine("Got {0} arguments", args.Length);
            foreach (string arg in args) {
                Console.WriteLine("{0}", arg);
            }
    
            return 0;
        }
    }
