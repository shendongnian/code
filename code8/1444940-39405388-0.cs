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
                XDocument doc = XDocument.Load(FILENAME);
                DataTable dt = new DataTable();
                dt.Columns.Add("Name", typeof(string));
                dt.Columns.Add("Value", typeof(int));
                dt.Columns.Add("Behaviour", typeof(int));
                foreach(XElement item in doc.Descendants("Item"))
                {
                    string name = (string)item.Element("name");
                    int value = (int)item.Element("value");
                    foreach (XElement behaviour in item.Descendants("behaviour"))
                    {
                        dt.Rows.Add(new object[] { name, value, (int)behaviour });
                    }
                }
            }
        }
    }
