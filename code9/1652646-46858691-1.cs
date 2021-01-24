    // Load text on Form Load
    private void Form1_Load(object sender, EventArgs e)
    {
        if (File.Exists(filePath))
        {
            richTextBox1.Lines = File.ReadAllLines(filePath);
        }
    }
    // Save text on button click
    private void button1_Click(object sender, EventArgs e)
    {
        File.WriteAllLines(filePath, richTextBox1.Lines);
    }
