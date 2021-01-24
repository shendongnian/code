    using System;
    using System.Runtime.InteropServices;
    class Program
    {
        [DllImport("libTest", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern int TestFunction();
        static void Main(string[] args)
        {
            Console.WriteLine("!!" + TestFunction());
        }
    }
