    using System;
    using System.Globalization;
    namespace StackOverflow_CurrencyParsing
    {
        class Program
        {
            static void Main(string[] args)
            {
                string total = "£100,000.00";
                decimal totalDecimal = decimal.Parse(total, NumberStyles.Currency, CultureInfo.GetCultureInfo("en-gb"));
                Console.WriteLine($"Total: {totalDecimal}");
                Console.ReadKey();
            }
        }
    }
