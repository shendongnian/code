    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                foreach(XElement client in doc.Descendants("client"))
                {
                    List<XElement> firstNames = client.Elements("firstName").ToList();
                    XElement newFirstName = new XElement(firstNames.FirstOrDefault());
                    firstNames.Remove();
                    client.AddFirst(newFirstName);
                }
            }
        }
    }
