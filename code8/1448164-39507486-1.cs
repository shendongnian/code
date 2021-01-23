    using System;
    using System.Globalization;
    
    class Test
    {
        static void Main()        
        {
            var culture = (CultureInfo) CultureInfo.GetCultureInfo("es-ES");
            var d = Decimal.Parse("1.234,56", culture);
            Console.WriteLine(d);
        }
    }
