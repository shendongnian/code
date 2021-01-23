    private void button1_Click(object sender, EventArgs e)
    {
        if (richTextBox1.SelectionFont == null)
            return;
        if (richTextBox1.SelectionFont.Bold)
            MessageBox.Show("All text is Bold");
        else if (richTextBox1.SelectedRtf.Replace(@"\\", "").IndexOf(@"\b") > -1)
            MessageBox.Show("Mixed Content");
        else
            MessageBox.Show("Text doesn't contain Bold");
    }
