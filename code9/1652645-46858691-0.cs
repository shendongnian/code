    // Load text on Form Load
    private void Form1_Load(object sender, EventArgs e)
    {
        if (File.Exists(filePath))
        {
            richTextBox1.Text = File.ReadAllText(filePath);
        }
    }
    // Save text on button click
    private void button1_Click(object sender, EventArgs e)
    {
        File.WriteAllText(filePath, richTextBox1.Text);
    }
