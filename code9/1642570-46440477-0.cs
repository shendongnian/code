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
                List<XElement> tests = doc.Descendants("Test").OrderBy(x => (int)x.Element("OriIndex")).ToList();
                int previousOriIndex = 0;
                for (int i = 0; i < tests.Count; i++)
                {
                    XElement test = tests[i];
                    int currentOriIndex = (int)test.Element("OriIndex");
                    test.Add(new XElement("SortedIndex", i));
                    test.Add(new XElement("DiffSortedIndex", i - currentOriIndex));
                    
                    if (i == 0)
                    {
                        test.Add(new XElement("DiffOriIndex", "NaN"));
                    }
                    else
                    {
                        test.Add(new XElement("DiffOriIndex", currentOriIndex - previousOriIndex));
                    }
                    previousOriIndex = currentOriIndex;
                    
                }
            }
        }
     
    }
