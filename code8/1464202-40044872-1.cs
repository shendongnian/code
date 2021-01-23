    namespace Testt
    {
        
        public partial class Form2 : Form
        {
            private Form1 f;
            public Form2(Form1 f1)
            {
                InitializeComponent();
                f=f1;
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                MessageBox.Show(f.dimx.ToString());
            }
        }
    }
