    for (int i=0; i<RichTextBox2.Lines.Length; i++)
    {
        var length = RichTextBox1.Lines.Length;
        RichTextBox3.Text += RichTextBox1.Lines[(i%length)] + RichTextBox2.Lines[i] + Environment.NewLine;
    }
