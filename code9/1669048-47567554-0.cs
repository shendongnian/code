    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                var response = doc.Descendants("RESPONSE").Select(x => new {
                    url = (string)x.Element("url"),
                    ttype = x.Elements().Where(y => (string)y.Attribute("name") == "ttype").Select(z => (string)z).FirstOrDefault(),
                    tempTxnId = x.Elements().Where(y => (string)y.Attribute("name") == "tempTxnId").Select(z => (string)z).FirstOrDefault(),
                    token = x.Elements().Where(y => (string)y.Attribute("name") == "token").Select(z => (string)z).FirstOrDefault(),
                    txnStage = x.Elements().Where(y => (string)y.Attribute("name") == "txnStage").Select(z => (int)z).FirstOrDefault()
                }).FirstOrDefault();
                
              
            }
        }
    }
