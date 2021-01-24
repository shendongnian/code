    using System;
    using System.Reflection;
    using System.Linq;
    using System.Xml.Linq;
    
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string xml1 = "<?xml version=\"1.0\" encoding=\"UTF - 8\"?> <note> <to>Tove</to> <from>Jani</from> <heading>Reminder</heading> <body>Don't forget me this weekend!</body> </note>";
                string xml2 = "<?xml version=\"1.0\" encoding=\"UTF - 8\"?> <note> <to>dd22</to> <from>Jani</from> <heading>4fewfewe</heading> <body>Don't forget me this weekend!</body> </note>";
    
                XDocument doc1 = XDocument.Parse(xml1);
                XDocument doc2 = XDocument.Parse(xml2);
                Console.WriteLine("Elements in document 1");
                foreach (string Different in doc1.Elements().Elements().Select(x => x.Value))
                {
                    Console.WriteLine("1----"+Different);
                }
                Console.Read();
    
                Console.WriteLine("Elements in document 2");
                foreach (string Different in doc2.Elements().Elements().Select(x => x.Value))
                {
                    Console.WriteLine("2----" + Different);
                }
    
                Console.Read();
    
                Console.WriteLine("These are the equal elements, I will discard different ones");
                foreach (string Different in doc1.Elements().Elements().Select(x => x.Value).Intersect(doc2.Elements().Elements().Select(x => x.Value)))
                {
                    Console.WriteLine(Different);
                }
                Console.Read();
            }
        }
    }
