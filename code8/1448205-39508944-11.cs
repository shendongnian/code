     public static decimal ToDecimal(this object value) {
       if (null == value)
         return 0.00m;
       try {
         return Convert.ToDecimal(value, CultureInfo.InvariantCulture);
       }
       catch (FormatException) {
         return 0.00m; 
       } 
     }
...
     // return me a decimal, please
     decimal d = "1799.00".ToDecimal();
     // when printing decimal, use Turkish culture
     Console.Write(d.ToString("N", CultureInfo.GetCultureInfo("tr-TR")));
