    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication1
    {
        class Program
        {
            
            static void Main(string[] args)
            {
                List<KeyValuePair<string, List<string>>> myList = new List<KeyValuePair<string,List<string>>>() {
                     new KeyValuePair<string, List<string>>("user1", new List<string> { "trigger1","trigger2","trigger3"}),
                     new KeyValuePair<string, List<string>>("user2", new List<string> { "trigger1","trigger4"}),
                     new KeyValuePair<string, List<string>>("user3", new List<string> { "trigger2","trigger3","trigger4"}),
                     new KeyValuePair<string, List<string>>("user1", new List<string> { "trigger0","trigger4"})
                };
                Dictionary<string, List<string>> dict = myList
                    .GroupBy(x => x.Key, y => y)
                    .ToDictionary(x => x.Key, y => y.Select(z => z.Value).SelectMany(a => a).ToList());
            }
        }
    }
