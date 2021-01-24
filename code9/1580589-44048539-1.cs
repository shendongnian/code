    using DataLib;
    using System;
    using System.Windows.Forms;
    
    namespace DataLibDemo
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            private void button1_Click(object sender, EventArgs e)
            {
                Operations1 ops = new Operations1();
                int newIdentifier = 0;
                if (ops.AddNewRow("O'brien and company", "Mary O'brien", ref newIdentifier))
                {
                    MessageBox.Show($"New Id for Mary {newIdentifier}");
                }
                else
                {
                    MessageBox.Show($"Insert failed: {ops.InsertException.Message}");
                }
    
                if (ops.AddNewRow("O'''brien and company", "Mary O'brien", ref newIdentifier))
                {
                    MessageBox.Show($"New Id for Mary {newIdentifier}");
                }
                else
                {
                    MessageBox.Show($"Insert failed: {ops.InsertException.Message}");
                }
            }
        }
    }
