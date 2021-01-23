    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication27
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                List<XElement> person_IDs = doc.Descendants("Person_ID").ToList();
                int count = 1;
                foreach (XElement person_ID in person_IDs)
                {
                    person_ID.Value = (count++).ToString();
                }
            }
        }
    }
