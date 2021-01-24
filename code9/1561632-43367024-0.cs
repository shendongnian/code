    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication49
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                string[] columnNames = doc.Descendants("record").FirstOrDefault().Elements().Select(x => x.Name.LocalName).ToArray();
                DataTable dt = new DataTable();
                foreach (string col in columnNames)
                {
                    dt.Columns.Add(col, typeof(string));
                }
                foreach (XElement record in doc.Descendants("record"))
                {
                    DataRow newRow = dt.Rows.Add();
                    foreach (string columnName in columnNames)
                    {
                        newRow[columnName] = (string)record.Element(columnName);
                    }
                }
            }
        }
    }
