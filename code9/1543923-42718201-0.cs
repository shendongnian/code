    List<string> numbers = new List<string>();
    
    private void Form1_Load(object sender, EventArgs e)
    {
        for (int i = 0; i < 1000; i++)
        {
            numbers.Add(_random.Next(min, max).ToString("D6"));
        }
        richTextBox1.Text = string.Join(Environment.NewLine, numbers);
    }
