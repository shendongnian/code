     using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Text.RegularExpressions;
        
        namespace PatternMatching
        {
            public class Program
            {
              public static void Main(string[] args)
        {
            string input = "You have 6 uncategorized contacts from <an id='316268655'>SAP SE</an>";
              
          
           var parts = Regex.Split(input, @"(<an[\s\S]+?<\/an>)").Where(l => l != string.Empty).ToArray();   
                  foreach(var a in parts)
                  {
                       Console.WriteLine(a);
                       break;
                  }
             string pattern = "<an.*?>(.*?)<\\/an>";      
          MatchCollection matches = Regex.Matches(input, pattern);
          
           if (matches.Count > 0)
             foreach (Match m in matches)
                   Console.WriteLine(m.Groups[1]);
        
            Console.ReadLine();
        }
            }
        }
