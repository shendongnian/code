    namespace StackOverflow
    {
        using System.IO;
        using System.Xml.Linq;
        class Program
        {
            static void Main(string[] args)
            {
                var xml1 = File.ReadAllText("test.xml");
                var doc1 = XDocument.Parse(xml1);
                var element = doc1.Root.Element("tananana");
                doc1.Root.Add(new XElement("something", element.Attributes()));
            }
        }
    }
