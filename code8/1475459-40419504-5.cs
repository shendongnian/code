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
                dt.Columns.Add("Refer_Id", typeof(int));
                dt.Columns.Add("Name", typeof(string));
                dt.Columns.Add("Salary", typeof(decimal));
                dt.Rows.Add(new object[] { 2457165, "ABC", 10000 });
                dt.Rows.Add(new object[] { 2457166, "DEF", 20000 });
                dt.Rows.Add(new object[] { 2457167, "GHI", 30000 });
                string header =
                    "<?xml version=\"1.0\" encoding=\"utf-8\" ?>" +
                    "<?mso-application progid=\"Excel.Sheet\"?>" +
                    "<Workbook" +
                    "  xmlns:x=\"urn:schemas-microsoft-com:office:excel\"" +
                    "  xmlns:ss=\"urn:schemas-microsoft-com:office:spreadsheet\"" +
                    "  xmlns=\"urn:schemas-microsoft-com:office:spreadsheet\">" +
                    "</Workbook>";
                XDocument doc = XDocument.Parse(header);
                XElement workbook = doc.Elements().Where(x => x.Name.LocalName == "Workbook").FirstOrDefault();
                XNamespace ssNs = workbook.GetNamespaceOfPrefix("ss");
                XNamespace xNs = workbook.GetNamespaceOfPrefix("x");
                XElement styles = new XElement("Styles", new object[] {
                    new XElement("Style", new object[] {
                        new XAttribute(ssNs + "ID", "Default"),
                        new XAttribute(ssNs + "Name", "Normal"),
                        new XElement("Alignment", new XAttribute(ssNs + "Vertical","Bottom")),
                        new XElement("Borders"),
                        new XElement("Font"),
                        new XElement("Interior"),
                        new XElement("Numberformat"),
                        new XElement("Protection")
                    }),
                    new XElement("Style", new object[] {
                        new XAttribute(ssNs + "ID", "s27"),
                        new XElement("Font", new object[] {
                            new XAttribute(xNs + "Family", "Swiss"),
                            new XAttribute(ssNs + "Color", "#0000FF"),
                            new XAttribute(ssNs + "Bold", 1)
                        }),
                    }),
                    new XElement("Style", new object[] {
                        new XAttribute(ssNs + "ID", "s21"),
                        new XElement("NumberFormat", new XAttribute(ssNs + "Format", "yyyy\\-mm\\-dd")),
                    }),
                    new XElement("Style", new object[] {
                        new XAttribute(ssNs + "ID", "s22"),
                        new XElement("NumberFormat", new XAttribute(ssNs + "Format", "yyyy\\-mm\\-dd\\ hh:mm:ss")),
                    }),
                    new XElement("Style", new object[] {
                        new XAttribute(ssNs + "ID", "s23"),
                        new XElement("NumberFormat", new XAttribute(ssNs + "Format", "hh:mm:ss")),
                    })
                });
                workbook.Add(styles);
                XElement table = new XElement(ssNs + "Table");
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
