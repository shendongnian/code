    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.IO;
    using System.Xml;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string URL = "https://batlgroupimages.blob.core.windows.net/files/MRNavigationMenu.xml";
            static void Main(string[] args)
            {
                MemoryStream stream = new MemoryStream();
                XmlWriter writer = XmlWriter.Create(stream);
                XmlDocument doc = new XmlDocument();
                doc.Load(URL);
                writer.WriteRaw(doc.OuterXml.ToString());
                writer.Flush();
            }
        }
     
    }
