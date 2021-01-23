    using System;
    using System.Text;
    using System.Windows.Forms;
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
                Nullable nullDateTime;
                //DateTime? nullDateTime = null;
                nullDateTime = DateTime.Now;
                if (nullDateTime != null)
                {
                    MessageBox.Show(nullDateTime.Value.ToString());
                }
            }
        }
    }
