    using System;
    using System.Text;
    
    class Program {
        static void Main(string[] args) {
            var infinity = "\u221e";
            Console.OutputEncoding = Encoding.GetEncoding(1252);
            Console.WriteLine(infinity);
            Console.ReadLine();
        }
    }
