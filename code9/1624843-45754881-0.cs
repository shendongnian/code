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
                string xml = File.ReadAllText(FILENAME);
                CreateNewOutputRows(xml);
            }
            static public void CreateNewOutputRows(string xml)
            {
                XDocument doc = XDocument.Parse(xml);
                XElement cacheEntryData = doc.Descendants().Where(x => x.Name.LocalName == "cacheEntryData").FirstOrDefault();
                string cacheEntryDataXml = WebUtility.HtmlDecode(cacheEntryData.ToString());
                XElement cacheEntryData2 = XElement.Parse(cacheEntryDataXml);
            }
        }
    }
