    public partial class Form2 : Form
    {
        public int Amount { get; private set; } = 0; 
    
        private void button1_Click(object sender, EventArgs e)
        {
            int tmp;
    
            Int32.TryParse(textBox2.Text, out tmp);
        
            this.Close();
        }
    }
