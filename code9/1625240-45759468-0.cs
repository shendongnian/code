    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.IO;
    using System.Net;
    namespace ConsoleApplication73
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                List<string> items = doc.Descendants("item").Select(x => (string)x).ToList();
            }
     
        }
    }
