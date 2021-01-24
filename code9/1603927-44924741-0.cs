    using System;
    using System.IO;
    using System.Xml;
    
    namespace FormatXMLStringConsoleApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                string rawStringXML = "<?xml version='1.0'?><user><details><name>xyz</name><class>mno</class><city>pqr</city></details><info><id>321</id><code>654</code></info></user>";
                XmlDocument xmlDoc = new XmlDocument();
                StringWriter sw = new StringWriter();
                xmlDoc.LoadXml(rawStringXML);
                xmlDoc.Save(sw);
                string formattedXml = sw.ToString();
                Console.WriteLine(formattedXml);
                Console.Read();
            }
        }
    }
