    using System;
    using System.Text.RegularExpressions;
    
    public class Example
    {
       public static void Main()
       {
          string pattern = @"\{[^{}]+value":([^{}]+)\}";
          string replacement = "$1";
          Regex rgx = new Regex(pattern);
          string input = YOUR_JSON_STRING;
          string result = rgx.Replace(input, replacement);
          Console.WriteLine(result);
       }
    }
