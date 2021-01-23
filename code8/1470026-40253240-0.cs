    using System;
    using System.Collections.Generic;
    using System.Globalization;
    namespace CurrencyFormatting_StackOverflow
    {
        class Program
        {
            static void Main(string[] args)
            {
                var strings = new List<string>()
                {
                    "2451.37",
                    "1678.00",
                    "12.00",
                    "90.00",
                    "10.00"
                };
                FormatStrings(strings);
                string display = string.Join("\n", strings);
                Console.WriteLine(display);
                Console.ReadKey();
            }
            private static void FormatStrings(List<string> strings)
            {
                int index = 0;
                for (; index < 2; index++)
                {
                    string s = strings[index];
                    double d = double.Parse(s);
                    string currency = d.ToString("C3", CultureInfo.CreateSpecificCulture("en-US"));
                    strings[index] = currency;
                }
                for (; index < strings.Count; index++)
                {
                    string s = strings[index];
                    double d = double.Parse(s);
                    double rounded = Math.Round(d, 2);
                    strings[index] = rounded + "";
                }
            }
        }
    }
