    // Load text on Form Load
    private void Form1_Load(object sender, EventArgs e)
    {
        if (File.Exists(filePath))
        {
            try
            {
                richTextBox1.LoadFile(filePath);
            }
            catch (ArgumentException)
            {
                // Fall back to plain text method if the 
                // file wasn't created by the RichTextbox
                richTextBox1.Text = File.ReadAllText(filePath);
            }
        }
    }
    // Save text on button click
    private void button1_Click(object sender, EventArgs e)
    {
        richTextBox1.SaveFile(filePath);
    }
