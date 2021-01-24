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
                XElement pictures = new XElement("pictures",doc.Descendants("DamagePictures"));
                for (int i = doc.Descendants("DamagePictures").Count() - 1; i >= 0; i--)
                {
                    XElement damagePicture = doc.Descendants("DamagePictures").Skip(i).FirstOrDefault();
                    if (i == 0)
                    {
                        damagePicture.ReplaceWith(pictures);
                    }
                    else
                    {
                        damagePicture.Remove();
                    }
                }
            }
        }
    }
