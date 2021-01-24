    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    namespace OpenWebPageOnCheckboxCheck_46934789
    {
        public partial class Form1 : Form
        {
            GroupBox gb1 = new GroupBox();
            GroupBox gb2 = new GroupBox();
            Button btn1 = new Button();
            Button btn2 = new Button();
            public Form1()
            {
                InitializeComponent();
                InitGroupBoxes();
                AddCheckboxesToGroup("check1", "www.google.com", gb1);
                AddCheckboxesToGroup("check2", "www.yahoo.com", gb1);
                AddCheckboxesToGroup("check3", "www.bing.com", gb1);
                AddCheckboxesToGroup("check4", "www.duckduckgo.com", gb1);
    
                AddCheckboxesToGroup("check1", "www.wikipedia.com", gb2);
                AddCheckboxesToGroup("check2", "www.stackoverflow.com", gb2);
    
                InitButtons();
            }
    
            private void InitButtons()
            {
                btn1.Text = "Open checked";
                btn1.Click += Btn1_Click;
                btn1.Location = new Point(145, 5);
                gb1.Controls.Add(btn1);
    
                btn2.Text = "Open checked";
                btn2.Click += Btn2_Click;
                btn2.Location = new Point(145, 5);
                gb2.Controls.Add(btn2);
            }
    
            private void Btn2_Click(object sender, EventArgs e)
            {
                foreach (Control item in gb2.Controls)
                {
                    if (item is CheckBox)
                    {
                        if (((CheckBox)item).Checked)
                        {
                            LaunchPage(item.Tag.ToString());
                        }
                    }
                }
            }
    
            private void Btn1_Click(object sender, EventArgs e)
            {
                foreach (Control item in gb1.Controls)
                {
                    if (item is CheckBox)
                    {
                        if (((CheckBox)item).Checked)
                        {
                            LaunchPage(item.Tag.ToString());
                        }
                    }
                }
            }
    
            private void AddCheckboxesToGroup(string cbText, string cbValue, GroupBox gb)
            {
                CheckBox cb = new CheckBox();
                cb.CheckedChanged += Cb_CheckedChanged;
                cb.Text = cbText;
                cb.Tag = cbValue;
                if (gb.Controls.Count > 0)
                {
                    cb.Location = new Point(gb.Controls[gb.Controls.Count - 1].Location.X, gb.Controls[gb.Controls.Count - 1].Location.Y + gb.Controls[gb.Controls.Count - 1].Height + 2);
                }
                else
                {
                    cb.Location = new Point(5, 5);
                }
                gb.Controls.Add(cb);
            }
    
            private void Cb_CheckedChanged(object sender, EventArgs e)
            {
                if (((CheckBox)sender).Checked)
                {
                    LaunchPage(((CheckBox)sender).Tag.ToString());
                }
            }
    
            private void LaunchPage(string pageURL)
            {
                System.Diagnostics.Process.Start(pageURL);
            }
    
            private void InitGroupBoxes()
            {
                gb1.Dock = DockStyle.Top;
                gb1.BackColor = Color.Aqua;
                gb2.Dock = DockStyle.Bottom;
                gb2.BackColor = Color.DarkRed;
                this.Controls.Add(gb1);
                this.Controls.Add(gb2);
            }
        }
    }
