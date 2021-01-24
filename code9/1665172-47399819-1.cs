    private bool lastKeyPressedWasBackspace;
    private void richTextBox_KeyDown(object sender, KeyEventArgs e)
    {
        lastKeyPressedWasBackspace = e.KeyCode == Keys.Back;
    }
    private void richTextBox1_TextChanged(object sender, EventArgs e)
    {
        if (!lastKeyPressedWasBackspace && richTextBox.Text.EndsWith("("))
        {
            richTextBox.AppendText(")");
        }
    }
