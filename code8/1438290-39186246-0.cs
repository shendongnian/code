    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Forms;
    
    namespace test
    {
        public class MyForm : Form
        {
            protected override void OnLoad(EventArgs e)
            {
                
                MessageBox.Show("test"); //call your method(s)
                base.OnLoad(e);
            }
        }
    }
