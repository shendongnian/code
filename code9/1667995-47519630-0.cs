    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Xml;
    using System.Xml.Linq;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                DataTable dt = new DataTable();
                dt.Columns.Add("DocName", typeof(string));
                dt.Columns.Add("Date", typeof(DateTime));
                dt.Columns.Add("software", typeof(string));
                dt.Columns.Add("Creator", typeof(string));
                dt.Columns.Add("nodeId", typeof(string));
                dt.Columns.Add("idVal", typeof(string));
                dt.Columns.Add("idSub", typeof(string));
                dt.Columns.Add("nodeName", typeof(string));
                dt.Columns.Add("namebore", typeof(string));
                dt.Rows.Add(new object[] { "name", DateTime.Parse("2016-02-25T12:52:00"), "Export", "export", "XXXXXXXXXXX", "XXXXXXXX", "XXXX", "XXXX", "namebore" });
                dt.Rows.Add(new object[] { "name", DateTime.Parse("2016-02-25T12:52:00"), "Export", "export", "XXXXXXXXXXX", "XXXXXXXX", "XXXX", "XXXX", "namebore" });
                dt.Rows.Add(new object[] { "name", DateTime.Parse("2016-02-25T12:52:00"), "Export", "export", "XXXXXXXXXXX", "XXXXXXXX", "XXXX", "XXXX", "namebore" });
                dataGridView1.DataSource = dt;
                var groups = dt.AsEnumerable()
                    .GroupBy(x => new { doc = x.Field<string>("DocName"), date = x.Field<DateTime>("date"), software = x.Field<string>("software"), creator = x.Field<string>("Creator") }).ToList();
                XElement parentNode = new XElement("ParentNode");
                foreach (var group in groups)
                {
                    XElement docInfo = new XElement("docInfo", new object[] {
                        new XElement("doc", group.Key.doc),
                        new XElement("fileinfo", new object[] {
                            new XElement("Date", group.Key.date.ToString("yyyy-MM-ddThh:mm:ss")),
                            new XElement("softwate", group.Key.software),
                            new XElement("Creator", group.Key.creator)
                        })
                    });
                    parentNode.Add(docInfo);
                    foreach (var row in group)
                    {
                        XElement repeatnode = new XElement("repeatnode", new object[] {
                            new XAttribute("id", row.Field<string>("nodeId")),
                            new XAttribute("idval", row.Field<string>("idVal")),
                            new XAttribute("idsub", row.Field<string>("idSub")),
                            new XElement("name", row.Field<string>("nodeName")),
                            new XElement("namebore", row.Field<string>("namebore"))
                        });
                        parentNode.Add(repeatnode);
                    }
                }
            }
        }
    }
