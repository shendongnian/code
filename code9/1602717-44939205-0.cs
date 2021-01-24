    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.IO;
    using System.Diagnostics;
    namespace BasketballScores
    {
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void BtnOutputData_Click(object sender, EventArgs e)
        {
            try
            {
                string path = "basketBallScore.txt";
                var c = new BasketballPlayer(path);
                ListView1.Items.Add(string.Format("\r\nAverage {0}", c.Average));
                ListView1.Items.Add(string.Format("\r\nFirst {0} {1}", c.Data.First().Name, c.Data.First().Value));
                ListView1.Items.Add(string.Format("\r\nLast {0} {1}", c.Data.Last().Name, c.Data.Last().Value));
                using (StreamWriter sw = File.AppendText(path))
                {
                    foreach (ListViewItem item in ListView1.Items)
                    {
                        sw.WriteLine(item.Text);
                        for (int i = 1; i < item.SubItems.Count; i++)
                        {
                            sw.WriteLine(item.SubItems[i].Text);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }        
      }
    }
