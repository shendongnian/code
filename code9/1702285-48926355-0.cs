    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication23
    {
        class Program
        {
            static void Main(string[] args)
            {
                DataTable dt = new DataTable("_InvTrans");
                dt.Columns.Add("IC", typeof(string));
                dt.Columns.Add("Stock", typeof(string));
                dt.Columns.Add("Desc", typeof(string));
                dt.Columns.Add("OppKind", typeof(string));
                dt.Columns.Add("Amount", typeof(string));
                dt.Columns.Add("Batch", typeof(string));
                dt.Columns.Add("Mat", typeof(string));
                dt.Rows.Add(new object[] { "010006", "1", "2 ", "1", "744", "6", "108208" });
                dt.Rows.Add(new object[] { "010006", "1", "2 ", "1", "744", "6", "108208" });
                dt.Rows.Add(new object[] { "010006", "1", "2 ", "1", "744", "6", "108208" });
                GetXmlTable(dt);
            }
            static XElement GetXmlTable(DataTable dt)
            {
                string tableName = dt.TableName;
                XElement table = new XElement(tableName);
                string[] columnNames = dt.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToArray();
                foreach (DataRow row in dt.AsEnumerable())
                {
                    XElement xRow = new XElement("_InvTrans");
                    table.Add(xRow);
                    foreach (string columnName in columnNames)
                    {
                        xRow.Add(new XAttribute(columnName, row[columnName]));
                    }
                }
                return table;
            }
        }
    }
