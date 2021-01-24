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
                string city = "London";
                string uri = string.Format("http://api.apixu.com/v1/forecast.xml?key=MyKey&q={0}&days=7", city);
                XDocument doc = XDocument.Load(uri);
                List<weather> we = new List<weather>();
                we.Add(new weather() { 
                    Maxtemp = (string)doc.Descendants("maxtemp_c").FirstOrDefault(),
                    Mintemp = (string)doc.Descendants("mintemp_c").FirstOrDefault()
                });
                dataGridView1.DataSource = we;
            }
        }
        public class weather
        {
            private string date;
            private string maxtemp;
            private string mintemp;
            private string maxwindmph;
            private string maxwindkph;
            private string humidity;
            public weather() { }
            public weather(string maxtemp, string mintemp, string maxwindmph, string maxwindkph, string humidity)
            {
                this.maxtemp = maxtemp;
                this.mintemp = mintemp;
                this.maxwindmph = maxwindmph;
                this.maxwindkph = maxwindkph;
                this.humidity = humidity;
            }
     
            public string Maxtemp
            {
                get { return maxtemp; }
                set { maxtemp = value; }
            }
            public string Mintemp
            {
                get { return mintemp; }
                set { mintemp = value; }
            }
            public string Maxwindmph
            {
                get { return maxwindmph; }
                set { maxwindmph = value; }
            }
        }
    }
