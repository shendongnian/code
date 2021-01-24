        for (int i = 0; i < lines.Count; i ++)
        {
            RichTextBoxExtensions.AppendText(richTextBox1, "Ready: ", Color.Red);
            richTextBox1.AppendText(lines[i] + (i < lines.Count-1 ? Environment.NewLine : String.Empty));
        }
