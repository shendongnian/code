    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication47
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                var results = doc.Descendants("sftp").Elements().Select(x => new
                {
                    name = x.Name.LocalName,
                    username = (string)x.Element("sftp-username"),
                    password = (string)x.Element("sftp-password"),
                    host = (string)x.Element("sftp-ipaddress"),
                    path = (string)x.Element("sftp-path")
                }).ToList();
            }
        }
    }
