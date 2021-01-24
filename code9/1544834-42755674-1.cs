    using System;
    using System.Drawing;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
     public partial class Form2 : Form
    {
        public Form2()
        {
        }
        public Form2(string title,string txt)
        {
            InitializeComponent();
            this.Text = title;
            label1.Text = txt;
        }
    }
    }
