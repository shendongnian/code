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
    namespace WindowsFormsApplication11
    {
        public partial class Form1 : Form
        {
            const string FILENAME = @"c:\temp\test.xml";
            public Form1()
            {
                InitializeComponent();
                DataTable dt = new DataTable();
                dt.Columns.Add("modelic", typeof(string));
                dt.Columns.Add("sdc", typeof(string));
                dt.Columns.Add("chapnum", typeof(string));
                dt.Columns.Add("section", typeof(string));
                dt.Columns.Add("subsect", typeof(string));
                dt.Columns.Add("subject", typeof(string));
                dt.Columns.Add("discode", typeof(string));
                dt.Columns.Add("discodev", typeof(string));
                dt.Columns.Add("incode", typeof(string));
                dt.Columns.Add("incodev", typeof(string));
                dt.Columns.Add("itemloc", typeof(string));
                XDocument doc = XDocument.Load(FILENAME);
                foreach (XElement avee in doc.Descendants().Where(x => x.Name.LocalName == "avee"))
                {
                    dt.Rows.Add(new object[] {
                        (string)avee.Element("modelic"),
                        (string)avee.Element("sdc"),
                        (string)avee.Element("chapnum"),
                        (string)avee.Element("section"),
                        (string)avee.Element("subsect"),
                        (string)avee.Element("subject"),
                        (string)avee.Element("discode"),
                        (string)avee.Element("discodev"),
                        (string)avee.Element("incode"),
                        (string)avee.Element("incodev"),
                        (string)avee.Element("itemloc")
                    });
                }
                dataGridView1.DataSource = dt;
     
            }
        }
    }
