    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Data;
    namespace ConsoleApplication65
    {
        class Program
        {
            static void Main(string[] args)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("CostCode", typeof(int));
                dt.Columns.Add("Date", typeof(DateTime));
                dt.Columns.Add("Reason", typeof(string));
                dt.Columns.Add("Comment", typeof(string));
                dt.Columns.Add("PropertyCode", typeof(int));
                dt.Rows.Add(new object[] { 1245, DateTime.Parse("2010-07-25"), "No Access 1", "Tenant is on holiday", 123456 });
                dt.Rows.Add(new object[] { null, DateTime.Parse("2010-07-26"), "No Access 2", "Tenant out at work", 123456 });
                dt.Rows.Add(new object[] { 1453, DateTime.Parse("2010-07-25"), "No Access 1", "Tenant in hospital", null });
                string header = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
                    "<regisApts xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">" +
                    "<JobList></JobList></regisApts>";
                XDocument doc = XDocument.Parse(header);
                XElement jobList = doc.Descendants("JobList").FirstOrDefault();
                foreach(DataRow row in dt.AsEnumerable())
                {
                    XElement job = new XElement("Job", new object[] {
                        new XAttribute("id", row.Field<object>("CostCode") == null ? "" : row.Field<int>("CostCode").ToString()),
                        new XElement("Date", row.Field<DateTime>("Date").ToString("yyyy-MM-dd")),
                        new XElement("Reason", row.Field<string>("Reason")),
                        new XElement("Comment", row.Field<string>("Comment")),
                        new XElement("ExternalJobNumber", row.Field<object>("PropertyCode") == null ? "" : row.Field<int>("PropertyCode").ToString())
                    });
                    jobList.Add(job);
                }
            }
        }
    }
