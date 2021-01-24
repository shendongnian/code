    static void Form1_Load(object sender, EventArgs e)
    {
        textBox1.TextChanged += textBox1UpdateButtonState;
    }
    static void textBox1UpdateButtonState(object sender, EventArgs e)
    {
        if(textBox1.Text.Length == 0)
        {
            button1.Enabled = false;
        }
        else
        {
            button1.Enabled = true;
        }
    }
