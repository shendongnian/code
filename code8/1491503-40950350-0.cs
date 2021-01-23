    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication29
    {
        class Program
        {
            const string URL = @"https://dumps.wikimedia.org/enwiki/20160820/enwiki-20160820-abstract26.xml";
            static void Main(string[] args)
            {
                XmlReader reader = XmlReader.Create(URL);
                while (!reader.EOF)
                {
                    if (reader.Name != "doc")
                    {
                        reader.ReadToFollowing("doc");
                    }
                    if (!reader.EOF)
                    {
                        XElement doc = (XElement)XElement.ReadFrom(reader);
                    }
                }
     
            }
        }
    }
