    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;
    using System.Xml.Linq;
    namespace _43387906
    {
        class Program
        {
            private static string _xml = "<ArrayOfGlobalInfo>\r\n <GlobalInfo>\r\n  <NumberOfEntries>2</NumberOfEntries>\r\n  <LanguageNewDefaultOptions />\r\n  <Languages>\r\n    <string>eng</string>\r\n    <string>ger</string>\r\n    <string>ita</string>\r\n    <string>fre</string>\r\n  </Languages>\r\n  <Valid>true</Valid>\r\n </GlobalInfo>\r\n</ArrayOfGlobalInfo>";
            static void Main(string[] args)
            {
                try
                {
                    var xDocument = XDocument.Parse(_xml);
                    UseXDocumentVerbose(xDocument);
                    UseXDocumentShorter(xDocument);
                    var xmlDocument = new XmlDocument();
                    xmlDocument.LoadXml(_xml);
                    UseXmlDocument(xmlDocument);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                Console.ReadLine();
            }
            private static void UseXmlDocument(XmlDocument xmlDocument)
            {
                var languages = xmlDocument.SelectNodes("ArrayOfGlobalInfo/GlobalInfo/Languages/string");
                //You can use languages.Count without converting to an array
                for (int i = 0; i < languages.Count; i++)
                {
                    Console.WriteLine(languages[i].InnerText);
                }
                //The trick is to use Cast<T>() and ToArray()
                var languagesArray = languages.Cast<XmlNode>().Select(n => n.InnerText).ToArray();
                for (int i = 0; i < languagesArray.Length; i++)
                {
                    Console.WriteLine(languagesArray[i]);
                }
            }
            private static void UseXDocumentShorter(XDocument xDocument)
            {
                if (xDocument.Root.Name != "ArrayOfGlobalInfo")
                    throw new Exception("Root isn't ArrayOfGlobalInfo");
                var languages = xDocument.Root
                                         .Elements("GlobalInfo")
                                         .SelectMany(i => i.Elements("Languages"))
                                         .SelectMany(l => l.Elements("string"))
                                         .Select(s => s.Value).Where(s => !string.IsNullOrWhiteSpace(s))
                                         .ToArray();
                for (int i = 0; i < languages.Length; i++)
                {
                    Console.WriteLine(languages[i]);
                }
            }
            private static void UseXDocumentVerbose(XDocument xDocument)
            {
                if (xDocument.Root.Name != "ArrayOfGlobalInfo")
                    throw new Exception("Root isn't ArrayOfGlobalInfo");
                var globalInfoElements = xDocument.Root.Elements("GlobalInfo");
                var languageElements = globalInfoElements.SelectMany(i => i.Elements("Languages"));
                var languages = languageElements.SelectMany(l => l.Elements("string")).Select(s => s.Value).Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();
                for (int i = 0; i < languages.Length; i++)
                {
                    Console.WriteLine(languages[i]);
                }
            }
        }
    }
