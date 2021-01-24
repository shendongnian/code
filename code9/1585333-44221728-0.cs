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
                List<XElement> removeNodes = doc.Descendants("WeaponSlots").Descendants("Item").Where(x => !x.Descendants("Entry").Where(y => (string)y == "SLOT_STUNGUN").Any()).ToList();
                foreach (XElement removeNode in removeNodes)
                {
                    removeNode.Remove();
                }
            }
        }
    }
