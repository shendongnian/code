    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication3
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
          
                List<string> data;
        private void button1_Click(object sender, EventArgs e)
            {
                data = new List<string>() { "Beginer", "C# Programer", "Object      ``Oriented" };
                comboBox1.DataSource = data;
            }
        }
        
    }
