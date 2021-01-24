    string[] textBoxLines = richTextBox1.Lines;
    for (int i = 0; i < textBoxLines.Length; i++)
    {
        string line = textBoxLines[i];
        if (line.StartsWith("3 ")) // define the line number which the commands occurred
        {
            richTextBox1.SelectionStart = richTextBox1.GetFirstCharIndexFromLine(i);
            richTextBox1.SelectionLength = line.Length;
            richTextBox1.SelectionFont  = new Font(richTextBox1.SelectionFont, FontStyle.Bold);
        }
    }
    // clear the selection
    richTextBox1.SelectionLength = 0;
