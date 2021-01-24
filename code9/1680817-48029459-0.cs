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
                string removeName = "Camara1";
                XElement camera = doc.Descendants().Where(x => (x.Name.LocalName == "Camera") && ((string)x.Attribute("Name") == removeName)).FirstOrDefault();
                camera.Remove();
            }
        }
    }
