        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            Form2 form2 = new Form2();
            private void textBox1_TextChanged(object sender, EventArgs e)
            {
                form2.textBox2.Text = textBox1.Text;
            }
            private void button1_Click(object sender, EventArgs e)
            {
                form2.Show();
            }
        }
