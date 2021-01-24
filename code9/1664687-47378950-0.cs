    using System;
    using System.Collections.Generic;
    
    namespace ConsoleApplication1
    {
        public static class Program
        {
            [STAThread]
            public static void Main(string[] args)
            {
                List<Int32> obj = new List<Int32>();
                obj.Add(123);
                obj.Add(56);
                obj.Add(34);
                obj.Add(87);
    
                foreach (Int32 value in obj)
                    Console.WriteLine(value.ToString());
    
                obj.Insert(3, 125);
    
                foreach (Int32 value in obj)
                    Console.WriteLine(value.ToString());
    
                obj.RemoveAt(2);
    
                foreach (Int32 value in obj)
                    Console.WriteLine(value.ToString());
            }
        }
    }
