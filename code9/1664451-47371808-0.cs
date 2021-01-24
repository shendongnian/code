    using System.IO;
    using System;
    
    class Program
    {
        // Very simple example, gonna throw exception for numbers bigger than 10^12
        static readonly string[] suffixes = {"", "k", "M", "G"};
        static string prettyCurrency(double cash, string prefix="$")
        {
            int k = (int)(Math.Log10(cash) / 3); // get number of digits and divide by 3
            var dividor = Math.Pow(10,k*3);  // actual number we print
            var text = prefix + (cash/dividor).ToString("F1") + suffixes[k];
            return text;
        }
        
        static void Main()
        {
            Console.WriteLine(prettyCurrency(333));
            Console.WriteLine(prettyCurrency(3145));
            Console.WriteLine(prettyCurrency(314512455));
            Console.WriteLine(prettyCurrency(31451242545));
        }
    }
