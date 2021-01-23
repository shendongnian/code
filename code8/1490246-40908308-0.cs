    using System.Xml.Linq;
    namespace ConsoleApplication29
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument xdoc = XDocument.Load(FILENAME);
                XElement total = xdoc.Descendants("Totals").First();
                total.ReplaceNodes(total.Elements().OrderBy(x => (int)x.Attribute("sequence")));
            }
     
        }
        
    }
