    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Collections;
    namespace Rextester
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                var l = new List<string> { "1D", "25B", "30A", "9C" };
        l.Sort((b, a) =>
        {
            var x = int.Parse(Regex.Replace(a, "[^0-9]", ""));
            var y = int.Parse(Regex.Replace(b, "[^0-9]", ""));
            if (x != y) return y - x;
            return -1 * string.Compare(a, b);
        });
    
        foreach (var item in l) Console.WriteLine(item);
      
            }
        }
    }
