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
            const string XML_FILENAME = @"c:\temp\test.xml";
            const string CSV_FILENAME = @"c:\temp\test.csv";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(XML_FILENAME);
                StreamWriter writer = new StreamWriter(CSV_FILENAME);
                XElement firstWorkUnit = doc.Descendants().Where(x => x.Name.LocalName == "WorkUnit").FirstOrDefault();
                XNamespace ns = firstWorkUnit.GetNamespaceOfPrefix("tlp");
                List<XElement> workUnits = doc.Descendants(ns + "WorkUnit").ToList();
                foreach (XElement workUnit in workUnits)
                {
                    string outputline = string.Join(",", new string[] {
                        (string)workUnit.Element(ns + "EmployeeID"),
                        (string)workUnit.Element(ns + "AllocationID"),
                        (string)workUnit.Element(ns + "TaskID"),
                        (string)workUnit.Element(ns + "ProjectID"),
                        (string)workUnit.Element(ns + "ProjectName"),
                        (string)workUnit.Element(ns + "CustomerId"),
                        (string)workUnit.Element(ns + "CustomerName"),
                        (string)workUnit.Element(ns + "IsBillable"),
                        (string)workUnit.Element(ns + "ApprovedStatus"),
                        (string)workUnit.Element(ns + "LastModifiedBy")
                    });
                    writer.WriteLine(outputline);
                }
                writer.Flush();
                writer.Close();
            }
        }
    }
