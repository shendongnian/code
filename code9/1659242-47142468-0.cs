    using System;
    using System.Windows.Forms;
    
    namespace StackOverflow
    {
        public partial class FormMain : Form
        {
            public FormMain()
            {
                InitializeComponent();
            }
    
            private void cbOS_SelectedIndexChanged(object sender, EventArgs e)
            {
                //Save selection.
                ComboBox cb = (ComboBox)(sender);
                btn1.CustomOS = cb.SelectedItem.ToString();
            }
    
            private void btnSelect_Click(object sender, EventArgs e)
            {
                //Restore selection on click.
                MyButton btn = (MyButton)(sender);
                cbOS.SelectedItem = btn.CustomOS;
            }
    
            //Declare a new class deriving from the classical Button.
            public class MyButton : Button
            {
                public String CustomOS { get; set; }    
                public String CustomLanguage { get; set; }
            }
        }
    }
