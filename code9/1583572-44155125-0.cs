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
    namespace WindowsFormsApplication29
    {
        public partial class Form1 : Form
        {
            const string FILENAME = @"c:\temp\test.xml";
            List<XElement> advertentie = null;
            int advertentieIndex = 0;
            public Form1()
            {
                InitializeComponent();
                XDocument doc = XDocument.Load(FILENAME);
                advertentie = doc.Descendants("advertentie").ToList();
                textBoxUserId.Text = (string)advertentie[advertentieIndex].Element("uId");
            }
                
     
            private void buttonPrevious_Click(object sender, EventArgs e)
            {
                if (advertentieIndex != 0)
                {
                    advertentieIndex -= 1;
                    textBoxUserId.Text = (string)advertentie[advertentieIndex].Element("uId");
                }
            }
            private void buttonNext_Click(object sender, EventArgs e)
            {
                if (advertentieIndex != advertentie.Count - 1)
                {
                    advertentieIndex += 1;
                    textBoxUserId.Text = (string)advertentie[advertentieIndex].Element("uId");
                }
            }
     
        }
    }
