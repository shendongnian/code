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
                string input = "(12000+15000)/2";
                string pattern = "\\d+";
                Regex rgx = new Regex(pattern);
                string result = rgx.Replace(input, callback);
            
                Console.WriteLine("Original String: {0}", input);
                Console.WriteLine("Replacement String: {0}", result);   
            }
        
            static string callback(Match m)
            {
                return  string.Format("{0:#,#}", Convert.ToInt32(m.ToString()));
            }
        }
    }
