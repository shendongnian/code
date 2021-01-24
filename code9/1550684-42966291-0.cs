    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    namespace Rextester
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                //Your code goes here
             string input = "<h4>Hello   World</h4>";
             string pattern = "<[^>]*>";
             string replacement = "";
             Regex rgx = new Regex(pattern);
             string result = rgx.Replace(input, replacement);
             Console.WriteLine("Original String: {0}", input);
             Console.WriteLine("Replacement String: {0}", result);    
             Console.ReadKey();
            }
        }
    }
