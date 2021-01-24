    private void Form1_Load(object sender, EventArgs e)
    {
        button1.Enabled = false;
    }
    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        button1.Enabled = textBox1.Text.Length > 0;
    }
