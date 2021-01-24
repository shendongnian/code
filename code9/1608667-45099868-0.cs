    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Data;
    namespace ConsoleApplication65
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                string[] uniqueIds = doc.Descendants("field").Select(x => (string)x.Attribute("id")).Distinct().ToArray();
                DataTable dt = new DataTable();
                foreach (string col in uniqueIds)
                {
                    dt.Columns.Add(col, typeof(string));
                }
                foreach (XElement field in doc.Descendants("field"))
                {
                    DataRow row = dt.Rows.Add();
                    row[(string)field.Attribute("id")] = (string)field.Attribute("value");
                }
            }
        }
    }
