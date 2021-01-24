    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using System.IO;
    using System.Linq;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                GetTextBoxValueFromCurrentTabPage();
                GetTextBoxValueFromAllTabPages();
            }
    
            private void GetTextBoxValueFromCurrentTabPage()
            {
                Dictionary<int, List<string>> dicTextBoxData = new Dictionary<int, List<string>>();
                foreach (var textBox in tabControl1.TabPages[tabControl1.SelectedIndex].Controls.OfType<TextBox>())
                {
                    if (textBox.Text.Trim() == "500")
                    {
                        if (dicTextBoxData.ContainsKey(tabControl1.SelectedIndex))
                        {
                            dicTextBoxData[tabControl1.SelectedIndex].Add(textBox.Text.Trim());
                        }
                        else
                        {
                            dicTextBoxData.Add(tabControl1.SelectedIndex, new List<string>() { textBox.Text.Trim() });
                        }
                    }
                }
            }
    
            private void GetTextBoxValueFromAllTabPages()
            {
                Dictionary<int, List<string>> dicTextBoxData = new Dictionary<int, List<string>>();
                foreach (TabPage tabPage in tabControl1.TabPages)
                {
                    foreach (var textBox in tabPage.Controls.OfType<TextBox>())
                    {
                        if (textBox.Text.Trim() == "500")
                        {
                            if (dicTextBoxData.ContainsKey(tabPage.TabIndex))
                            {
                                dicTextBoxData[tabPage.TabIndex].Add(textBox.Text.Trim());
                            }
                            else
                            {
                                dicTextBoxData.Add(tabPage.TabIndex, new List<string>() { textBox.Text.Trim() });
                            }
                        }
                    }
                }
            }
    
        
        }
    }
