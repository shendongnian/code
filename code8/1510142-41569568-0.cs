    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication34
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                List<string> orderStrings = new List<string>() { "b", "a", "z" };
                List<List<object>> data = new List<List<object>>() {
                    new List<object> {"a", 1},
                    new List<object> {"a", 2},
                    new List<object> {"a", 3},
                    new List<object> {"a", 4},
                    new List<object> {"b", 5},
                    new List<object> {"b", 6},
                    new List<object> {"b", 7},
                    new List<object> {"z", 8},
                    new List<object> {"z", 9},
                };
                var results = data.GroupBy(x => x[0]).OrderBy(x => orderStrings.IndexOf((string)x.Key)).ToList();
     
            }
        }
    }
