    using System;
    class Program
    {
        static void Main()
        {
            Random r = new Random();
            Console.WriteLine(String.Format("{0:C}", r.Next()));
        }
    }
