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
                DataTable dt = new DataTable();
                XDocument table = XDocument.Load(FILENAME);
                List<XElement> rows = table.Descendants("tr").ToList();
                foreach (XElement col in rows[0].Elements("th").ToArray())
                {
                    dt.Columns.Add((string)col, typeof(string));
                }
                for (int i = 1; i < rows.Count; i++)
                {
                    dt.Rows.Add(rows[i].Elements("td").Select(x => (string)x).ToArray());
                }
                DataTable dt1 = dt.AsEnumerable().Where(x => x.Field<string>("ItemName") == "Item1").CopyToDataTable();
                DataTable dt2 = dt.AsEnumerable().Where(x => x.Field<string>("ItemName") == "Item2").CopyToDataTable();
     
            }
        }
    }
