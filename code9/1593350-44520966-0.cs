    using System;
    using System.Globalization;
    
    static class DecimalTest
    {
        static void Main(string[] args)
        {
            var dec = 0M;
            var decStr = "450.000000";
            var nfi = new NumberFormatInfo { NumberDecimalSeparator = "." };
            var parsed = decimal.TryParse(decStr, default(NumberStyles),
                                          nfi, out dec);
            if (parsed)
                Console.WriteLine("Decimal value: {0}", dec);
            else
                Console.WriteLine("Sheet happened!");
        }
    }
