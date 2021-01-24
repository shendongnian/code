    using System;
    using System.Threading.Tasks;
    
    namespace Testificate
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                Task.Run(() => Alert()).Wait();
            }
    
            private static void Alert()
            {
                Console.WriteLine("Test");
            }
        }
    }
