    using System;
    using System.Globalization;
    
    public class Example
    {
       public static void Main()
       {
          string str1 = "Hello (T) How";
          string str2 = "Hello [T] How";
          string str3 = "Hello [X] How";
          
          var compare1And2 = String.Compare(str1, str2, CultureInfo.InvariantCulture, CompareOptions.IgnoreSymbols);
          var compare1And3 = String.Compare(str1, str3, CultureInfo.InvariantCulture, CompareOptions.IgnoreSymbols);
          
          System.Console.WriteLine(compare1And2); // 0 
          System.Console.WriteLine(compare1And3); // -1
       }
    }
