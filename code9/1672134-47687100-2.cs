    private void editToolStripMenuItem_Click(object sender, EventArgs e)
    {
        MakeTextBoxEditable(itxt_CommonTitle);
    }
    private void itxt_CommonTitle_Leave(object sender, EventArgs e)
    {
        MakeTextBoxReadOnly(itxt_CommonTitle);
    }
    private void Form1_Click(object sender, EventArgs e)
    {
        MakeTextBoxReadOnly(itxt_CommonTitle);
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
