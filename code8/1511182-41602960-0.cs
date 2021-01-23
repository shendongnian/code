    using System;
    using System.IO;
    using System.Windows.Forms;
    
    namespace Jonny
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void btnAddItems_Click(object sender, EventArgs e)
            {
                {
                    OpenFileDialog ofd = new OpenFileDialog();
                    ofd.Filter = "Names|*.txt";
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        string[] recipients = File.ReadAllLines(ofd.FileName);
    
                        foreach (string name in recipients)
                        {
                            lvRecipient.Items.Add(name);
                            //increment the number of items in the list
                            foreach (var item in lvRecipient.Items)
                            {
                                int i = 0;
                                i++;
                                lbCount.Text = i.ToString();
                            }
                        }
                    }
                }
            }
        }
    }
