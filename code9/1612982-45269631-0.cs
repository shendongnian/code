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
                DataTable dt = new DataTable();
                dt.Columns.Add("version", typeof(int));
                dt.Columns.Add("date", typeof(DateTime));
                dt.Columns.Add("author", typeof(string));
                dt.Columns.Add("msg", typeof(string));
                dt.Columns.Add("paths", typeof(string));
                dt.Columns.Add("action", typeof(string));
                XDocument doc = XDocument.Load(FILENAME);
                foreach(XElement logentry in doc.Descendants("logentry"))
                {
                    foreach(XElement path in logentry.Descendants("path"))
                    {
                        dt.Rows.Add(new object[] {
                            (int)logentry.Attribute("version"),
                            (DateTime)logentry.Element("date"),
                            (string)logentry.Element("author"),
                            (string)logentry.Element("msg"),
                            (string)path.FirstNode.ToString(),
                            (string)path.Attribute("action")
                        });
                    }
                }
            }
        }
    }
