    public Form1()
            {
                InitializeComponent();
                textBox9.Enabled = false;
            }
           
            private void textBox7_TextChanged(object sender, EventArgs e)
            {
                
                if (Int32.Parse(textBox1.Text.Trim()) > 0)
                {
                    textBox9.Enabled = true;
                }
                else
                {
                    textBox9.Enabled = false;
                }
            }
