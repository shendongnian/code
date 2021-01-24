    using System.Windows.Forms;
    namespace WindowsFormsApplication2
    {
        public partial class Form1 : Form
        {
            public Form1 ()
            {
                InitializeComponent ();
            }
            private void Form1_FormClosing (object sender, FormClosingEventArgs e)
            {
                var result = MessageBox.Show ("My App", "Really quit?", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    // close connection
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }
    }
