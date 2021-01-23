    string text1;
    private void richTextBox1_Leave(object sender, EventArgs e)
        {
            text1 = richTextBox1.Text;
            richTextBox1.Rtf = @"{\rtf1\ansi " + richTextBox1.Text;
        }
        private void richTextBox1_Enter(object sender, EventArgs e)
        {
            richTextBox1.Text = text1;
        }
