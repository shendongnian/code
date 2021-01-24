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
    using System.Net;
    using System.IO;
    namespace WindowsFormsApplication3
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                DataTable dt = new DataTable();
                dt.Columns.Add("Date", typeof(string));
                dt.Columns.Add("Max Temp", typeof(string));
                dt.Columns.Add("Min Temp", typeof(string));
                dt.Columns.Add("Text", typeof(string));
                dt.Columns.Add("Icon", typeof(Bitmap));
                string city = "London";
                string uri = string.Format("http://api.apixu.com/v1/forecast.xml?key=keygoeshere&q={0}&days=7", city);
                XDocument doc = XDocument.Load(uri);
                foreach (var npc in doc.Descendants("forecastday"))
                {
                    string iconUri = (string)npc.Descendants("icon").FirstOrDefault();
                    WebClient client = new WebClient();
                    byte[] image = client.DownloadData("http:" + iconUri);
                    MemoryStream stream = new MemoryStream(image);
      
                    
                    
                    Bitmap newBitMap = new Bitmap(stream);
                    dt.Rows.Add(new object[] {
                        (string)npc.Descendants("date").FirstOrDefault(),
                        (string)npc.Descendants("maxtemp_c").FirstOrDefault(),
                        (string)npc.Descendants("mintemp_c").FirstOrDefault(),
                        (string)npc.Descendants("text").FirstOrDefault(),
                        newBitMap
                    });
                }
                dataGridView1.DataSource = dt;
            }
        }
    }
