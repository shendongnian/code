    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication2
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
               XDocument doc = XDocument.Load(FILENAME);
               string rfc = doc.Descendants().Where(x => x.Name.LocalName == "Receptor").Select(x => (string)x.Attribute("rfc")).FirstOrDefault();
               string UUID = doc.Descendants().Where(x => x.Name.LocalName == "TimbreFiscalDigital").Select(x => (string)x.Attribute("UUID")).FirstOrDefault();
            }
        }
    }
