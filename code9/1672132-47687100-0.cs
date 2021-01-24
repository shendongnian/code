    private void editToolStripMenuItem_Click(object sender, EventArgs e)
    {
        MakeTextBoxEditable(textBox1);
    }
    private void textBox1_Leave(object sender, EventArgs e)
    {
        MakeTextBoxReadOnly(textBox1);
    }
    private void Form1_Click(object sender, EventArgs e)
    {
        MakeTextBoxReadOnly(textBox1);
    }
    private Color origTextBoxBackColor = SystemColors.Control;
    private void MakeTextBoxEditable(TextBox textBox)
    {
        origTextBoxBackColor = textBox.BackColor;
        textBox.ReadOnly = false;
        textBox.BackColor = Color.White;
        textBox.Focus();
    }
    private void MakeTextBoxReadOnly(TextBox textBox)
    {
        textBox.ReadOnly = true;
        textBox.BackColor = origTextBoxBackColor;
    }
