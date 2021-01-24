    namespace WindowsFormsApplication1
    {
        public partial class Form2 : Form
        {
            public string test;
            public Form2()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                test = textBox1.Text;
                this.Hide();
            }
        }
    }
