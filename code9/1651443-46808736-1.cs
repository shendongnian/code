    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    using Wmhelp.XPath2;
    namespace My.Library
    {
        [TestClass]
        class WmhelpTests
        {
            [TestMethod]
            public void LibraryTest()
            {
                string xmlFromMessage = @"<Library>
                    <Writer ID=""writer1""><Name>Shakespeare</Name></Writer>
                    <Writer ID=""writer2""><Name>Tolkien</Name></Writer>
                    <Book><WriterRef REFID=""writer1"" /><Title>King Lear</Title></Book>
                    <Book><WriterRef REFID=""writer2"" /><Title>The Hobbit</Title></Book>
                    <Book><WriterRef REFID=""writer2"" /><Title>Lord of the Rings</Title></Book>
                </Library>";
                var titleXPathFromConfigurationFile = "./Title";
                var writerXPathFromConfigurationFile = "for $curr in . return ../Writer[@ID=$curr/WriterRef/@REFID]/Name";
                var library = ExtractBooks(xmlFromMessage, titleXPathFromConfigurationFile, writerXPathFromConfigurationFile).ToDictionary(b => b.Key, b => b.Value);
                Assert.AreEqual("Shakespeare", library["King Lear"]);
                Assert.AreEqual("Tolkien", library["The Hobbit"]);
                Assert.AreEqual("Tolkien", library["Lord of the Rings"]);
            }
            public IEnumerable<KeyValuePair<string, string>> ExtractBooks(string xml, string titleXPath, string writerXPath)
            {
                var library = XDocument.Parse(xml);
                foreach (var book in library.Descendants().Where(d => d.Name == "Book"))
                {
                    var title = book.XPath2SelectElement(titleXPath).Value;
                    var writer = book.XPath2SelectElement(writerXPath).Value;
                    yield return new KeyValuePair<string, string>(title, writer);
                }
            }
        }
    }
