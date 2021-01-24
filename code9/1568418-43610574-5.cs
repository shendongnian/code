    namespace StackOverflow
    {
        using System.IO;
        using System.Linq;
        using System.Xml.Linq;
        class Program
        {
            static void Main(string[] args)
            {
                var xml = File.ReadAllText("test.xml");
                var doc1 = XDocument.Parse(xml);
                var doc2 = new XDocument(new XElement(doc1.Root.Name));
                doc2.Root.Add(doc1.Root
                    .Elements("tananana")
                    .Select(x => new XElement("something", x.Attributes())));
            }
        }
    }
