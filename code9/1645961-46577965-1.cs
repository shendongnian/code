    using System;
    using System.Windows.Forms;
    using System.IO;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private System.Windows.Forms.DialogResult dialogFunction()
            {
                Stream myStream = null;
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Reset();
                openFileDialog1.InitialDirectory = "c:\\";
                openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog1.FilterIndex = 2;
                openFileDialog1.RestoreDirectory = true;
    
                return (openFileDialog1.ShowDialog());
                
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                if (dialogFunction() == System.Windows.Forms.DialogResult.OK)
                {
                 /*do stuff*/   
                }
            }
    
            private void button2_Click(object sender, EventArgs e)
            {
                if (dialogFunction() == System.Windows.Forms.DialogResult.OK)
                {
                    /*do stuff*/
                }
    
            }
    
            
        }
    }
