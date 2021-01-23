    using System.Xml;
    using System.Xml.Linq;
    using System.IO;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication28
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                string xml = File.ReadAllText(FILENAME);
                string pattern = @"(?'open'<)(?'cdata'!\[CData[^\>]+)(?'close'>)";
                string fixedXml = Regex.Replace(xml, pattern, "${cdata}");
                XDocument doc = XDocument.Parse(fixedXml);
            }
        }
    }
