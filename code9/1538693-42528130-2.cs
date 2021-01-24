    using System;
    using System.Linq;
    using System.Xml.Linq;
    
    class Test
    {
        static void Main()
        {
            var doc = new XDocument(new XElement ("root",
                new XElement("child1", new XElement("grandchild1")),
                new XElement("child2", new XElement("grandchild2"))));
                                    
            Console.WriteLine("Document before:");
            Console.WriteLine(doc);
    
            doc.Root.Elements().Skip(1).Remove();
            
            Console.WriteLine("Document after:");
            Console.WriteLine(doc);
        }
    }
