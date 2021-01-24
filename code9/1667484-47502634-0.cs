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
            const string FILENAME = @"c:\temp\test.xml";
            public Form1()
            {
                InitializeComponent();
                DataTable dt = new DataTable();
                dt.Columns.Add("name", typeof(string));
                dt.Columns.Add("team", typeof(string));
                dt.Columns.Add("atBats", typeof(int));
                dt.Columns.Add("hits", typeof(int));
                XDocument doc = XDocument.Load(FILENAME);
                foreach(XElement play in doc.Descendants("player"))
                {
                    dt.Rows.Add(new object[] {
                        (string)play.Element("name"),
                        (string)play.Element("team"),
                        (int)play.Element("atBats"),
                        (int)play.Element("hits")
                    });
                }
                dataGridView1.DataSource = dt;
            }
        }
    }
