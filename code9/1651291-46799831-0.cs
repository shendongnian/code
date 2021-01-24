    using System;
    using System.Linq;
    using System.Xml.Linq;
    
    namespace ConsoleTester
    {
        class Program
        {
            static void Main(string[] args)
            {
                //Here I am mocking your file statically, you could iterate here through a file system.
                var xml =
                    "<?xml version=\"1.0\"?><movement><skill id = \"2\"><cooldown>5</cooldown></skill><skill id = \"3\"><cooldown>10</cooldown></skill></movement>";
    
                //Just parse the file from the text obtained from a StreamReader or similar.
                var xdoc = XDocument.Parse(xml);
                //Chain the events of finding the node(s) you want with 'Elements' then continuing on to more, then you want an Attribute and not a node.  Then select it's value.
                xdoc.Elements("movement").Elements("skill").Attributes("id")
                    .Select(x => x.Value)
                    .ToList()
                    .ForEach(x => Console.WriteLine(x));
                
    
                Console.ReadLine();
            }
        }
    }
