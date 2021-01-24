    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    
    namespace ConsoleApplication
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<int> list = new List<int>() { 1, 2, 3 };
                var document = new XDocument(new XElement("root",  list.Select(x => new XElement("item", x))));
                Console.WriteLine("print:" + document);
            }
        }
    }
