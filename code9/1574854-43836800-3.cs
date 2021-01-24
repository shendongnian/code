    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace FinalProject
    {
    
    public partial class Form2 : Form
    {
        public static int operation;
        public static int digits;
    
        public Form2()
        {
            InitializeComponent();
            
        }
        //do NOT paste this. It can be added by creating an event handler
        // you also might not need this, but this method is called when this Form appears. It's an example.
        // https://msdn.microsoft.com/en-us/library/zwwsdtbk(v=vs.80).aspx
        private void Form2_Load(object sender, EventArgs e)
        {
           //here you can use your variables for example (also anywhere within this class!)
           //e.g.
           Textbox1.Text = (string)operation;   
        }
    
        private void FinishedBtn_Click(object sender, EventArgs e)
        {
    
    
        }
    }
    }
