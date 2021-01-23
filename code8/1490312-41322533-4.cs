    using System;
    using System.Text;
    using System.Threading;
    using System.Globalization;
    
    class Program {
        static void Main(string[] args) {
            Console.OutputEncoding = Encoding.GetEncoding(1252);
            var ci = (CultureInfo)Thread.CurrentThread.CurrentCulture.Clone();
            ci.NumberFormat.NegativeInfinitySymbol = "-Infinity";
            ci.NumberFormat.PositiveInfinitySymbol = "And beyond";
            Thread.CurrentThread.CurrentCulture = ci;
            Console.WriteLine(1 / 0.0);
            Console.ReadLine();
        }
    }
