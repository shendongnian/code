    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Data;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                XElement firstWorkUnit = doc.Descendants().Where(x => x.Name.LocalName == "WorkUnit").FirstOrDefault();
                XNamespace ns = firstWorkUnit.GetNamespaceOfPrefix("tlp");
                //create datatable
                DataTable dt = new DataTable();
                foreach (XElement col in firstWorkUnit.Elements())
                {
                    dt.Columns.Add(col.Name.LocalName, typeof(string));
                }
                List<XElement> workUnits = doc.Descendants(ns + "WorkUnit").ToList();
                foreach (XElement workUnit in workUnits)
                {
                    DataRow newRow = dt.Rows.Add();
                    foreach(XElement col in workUnit.Elements())
                    { 
                           newRow[col.Name.LocalName] = (string)col;
                    }
                }
                List<string> projId = dt.AsEnumerable().Select(x => x.Field<string>("ProjectID")).ToList();
            }
        }
    }
