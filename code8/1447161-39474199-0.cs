    namespace FSociety {
    
    public partial class Form2 : Form
    {
        public Form2()
        {
    
                InitializeComponent();
        }
    
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
    
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "root"
                && textBox2.Text == "toor")           
                {
                progressBar1.Increment(100);
    
                }
    
            else
            {
                MessageBox.Show("Wrong username or password");
    
            }
    
        }
    }
    
    }
