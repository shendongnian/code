    using System;
    using System.Text.RegularExpressions;
    
    public class Example
    {
       public static void Main()
       {
          string input = "hello world this is sample text";
          string pattern = @"(\w+\s+){2}(.*)";
          string replacement = "$1";
          Regex rgx = new Regex(pattern);
          string result = rgx.Replace(input, replacement);
    
          Console.WriteLine("Original String: {0}", input);
          Console.WriteLine("Replacement String: {0}", result);                             
       }
    }
