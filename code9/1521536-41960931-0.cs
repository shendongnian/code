    foreach (string line in lines)
    {
        RichTextBoxExtensions.AppendText(richTextBox1, "Ready: ", Color.Red);
        richTextBox1.AppendText(line + Environment.NewLine);
    }
