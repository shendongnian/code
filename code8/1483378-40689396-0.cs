    using System;
    using System.Diagnostics;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
         public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                foreach (Control c in this.Controls)
                {
                    c.Validated += C_Validated;
                }
            }
            private void C_Validated(object sender, EventArgs e)
            {
            Debug.Print($"{sender.GetType().FullName} had Validated event called");
            }
        }
    }
