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
                DataTable datatableListUser = new DataTable();
                datatableListUser.Clear();
                datatableListUser.Columns.Add("uuid");
                datatableListUser.Columns.Add("firstName", typeof(string));
                datatableListUser.Columns.Add("middleName", typeof(string));
                datatableListUser.Columns.Add("lastName", typeof(string));
                datatableListUser.Columns.Add("primaryExtensionPattern", typeof(int));
                XDocument doc = XDocument.Load(FILENAME);
                foreach (XElement user in doc.Descendants("user"))
                {
                    datatableListUser.Rows.Add(new object[] {
                       (string)user.Attribute("uuid"),
                       (string)user.Element("firstName"),
                       (string)user.Element("middleName"),
                       (string)user.Element("lastName"),
                       (int)user.Descendants("pattern").FirstOrDefault()
                    });
                }
            }
        }
    }
