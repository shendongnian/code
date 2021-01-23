    using System;
    using System.Globalization;
    
    class Test
    {
        static void Main()        
        {
            // Call clone to make sure it's mutable
            var culture = (CultureInfo) CultureInfo.GetCultureInfo("fr-FR").Clone();
            culture.NumberFormat.NumberGroupSeparator = ".";
            var d = Decimal.Parse("1.234,56", culture);
            Console.WriteLine(d);
        }
    }
