    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                const string xmlString = "<Object><Item>Word</Item><Value>10</Value></Object>";
                StringReader sReader = new StringReader(xmlString);
                XmlReader xReader = XmlReader.Create(sReader);
                while (!xReader.EOF)
                {
                    if (xReader.Name != "Object")
                    {
                        xReader.ReadToFollowing("Object");
                    }
                    if (!xReader.EOF)
                    {
                        XElement _object = (XElement)XElement.ReadFrom(xReader);
                    }
                }
                
       
            }
        }
    }
