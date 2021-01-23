    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XmlReader reader = XmlReader.Create(FILENAME);
                if (reader.Name != "database")
                {
                    reader.ReadToFollowing("database");
                }
                reader.MoveToFirstAttribute();
                string databaseName = reader.Value;
                DataSet ds = new DataSet(databaseName);
                DataTable dt = null;
                while (!reader.EOF)
                {
                    if (reader.Name != "table")
                    {
                        reader.ReadToFollowing("table");
                    }
                    if (!reader.EOF)
                    {
                        XElement table = (XElement)XElement.ReadFrom(reader);
                        string tableName = (string)table.Attribute("name");
                        if (!ds.Tables.Contains(tableName))
                        {
                            dt = new DataTable(tableName);
                            ds.Tables.Add(dt);
                            dt.Columns.AddRange(table.Elements("column").Select(x => new DataColumn((string)x.Attribute("name"))).ToArray());
                        }
                        DataRow newRow = ds.Tables[tableName].Rows.Add();
                        newRow.ItemArray = table.Elements("column").Select(x => (string)x).ToArray();
                    }
                }
            }
        }
    }
