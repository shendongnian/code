    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Data;
    namespace ConsoleApplication23
    {
        class Program
        {
            static void Main(string[] args)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Refer_Id",typeof(int));
                dt.Columns.Add("Name",typeof(string));
                dt.Columns.Add("Salary",typeof(decimal));
                dt.Rows.Add(new object[] { 2457165, "ABC", 10000 });
                dt.Rows.Add(new object[] { 2457166, "DEF", 20000 });
                dt.Rows.Add(new object[] { 2457167, "GHI", 30000 }); 
                string header =
                    "<?xml version=\"1.0\" encoding=\"utf-8\" ?>" +
                    "<Workbook xmlns:ss=\"\\\\your namespace here\">" +
                    "</Workbook>";
                XDocument doc = XDocument.Parse(header);
                XElement workbook = (XElement)doc.FirstNode;
                XNamespace ssNs = workbook.GetNamespaceOfPrefix("ss");
                XElement table = new XElement("Table");
                workbook.Add(table);
                XElement newRow = new XElement(ssNs + "Row");
                table.Add(newRow);
                foreach (DataColumn col in dt.Columns)
                {
                    newRow.Add(new XElement(ssNs + "Cell", new object[] {
                        new XAttribute(ssNs + "StyleID", "s27"),
                        new XElement(ssNs + "Data", new object[] {
                            new XAttribute(ssNs + "Type", "String"),
                            col.ColumnName
                        })
                    }));
                }
                foreach (DataRow row in dt.AsEnumerable())
                {
                    newRow = new XElement(ssNs + "Row");
                    table.Add(newRow);
                    string[] itemArray = row.ItemArray.Select(x => x.ToString()).ToArray();
                    foreach (string item in itemArray)
                    {
                        newRow.Add(new XElement(ssNs + "Cell", new object[] {
                        new XElement(ssNs + "Data", new object[] {
                            new XAttribute(ssNs + "Type", "String"),
                            item
                            })
                        }));
                    }
                }
            }
        }
    }
