    using System;
    using System.Linq;
    using System.Text.RegularExpressions;
    
    namespace ConsoleApplication15
    {
        class Program
        {
            static void Main(string[] args)
            {
                string str = "'DC0008_','23802.76','23802.76','23802.76','Comm,erc,','2f17','3f44c0ba-daf1-44f0-a361-'";
                var matches = Regex.Matches(str, "(?<=')[^,].*?(?=')");
                var array = matches.Cast<Match>().Select(x => x.Value).ToArray();
                foreach (var item in array)
                Console.WriteLine(item);
            }
        }
    }
