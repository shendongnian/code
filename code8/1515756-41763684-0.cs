    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.IO;
    using System.Data;
    namespace ConsoleApplication42
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                StreamReader reader = new StreamReader(FILENAME, Encoding.UTF8);
                reader.ReadLine();  //ignore xml definition
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.ConformanceLevel = ConformanceLevel.Fragment;
                XmlReader xReader = XmlReader.Create(reader, settings);
                XElement doc = XElement.Load(xReader);
                DataSet ds = new DataSet();
                string[] columnHeaders = null;
                foreach (XElement table in doc.Element("Rows").Elements("ReportRow"))
                {
                    string type = (string)table.Descendants("RowType").FirstOrDefault();
                    switch (type)
                    {
                        case "Header" :
                            columnHeaders = table.Descendants("Value").Select(x => (string)x).ToArray();
                            break;
                        case "Section":
                            string name = (string)table.Element("Title");
                            DataTable dt = new DataTable(name);
                            for (int index = 0; index < columnHeaders.Length; index++)
                            {
                                if (index == 0)
                                {
                                    dt.Columns.Add(columnHeaders[index], typeof(string));
                                }
                                else
                                {
                                    dt.Columns.Add(columnHeaders[index], typeof(decimal));
                                }
                            }
                            ds.Tables.Add(dt);
                            foreach (XElement datarow in table.Descendants("ReportRow"))
                            {
                                DataRow newRow = dt.Rows.Add();
                                string[] values = datarow.Descendants("ReportCell").Elements("Value").Select(x => (string)x).ToArray();
                                for (int index = 0; index < values.Length; index++)
                                {
                                    switch (index)
                                    {
                                        case 0 :
                                            newRow[index] = values[index];
                                            break;
                                        default :
                                            newRow[index] = decimal.Parse(values[index]);
                                            break;
                                    }
                                }
                            }
                            break;
                    }
                }
            }
        }
     
    }
