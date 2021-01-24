    using System;
    using System.Text.RegularExpressions;
                        
    public class Program
    {
        public static void Main()
        {
            string pattern = @"@\w+";
            var r = new Regex(pattern);
            Console.WriteLine(r.Replace("ABC @ABC ABC @DEF klm.@bhsh", "BOOM!"));
        }
    }
