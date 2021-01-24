    private void Form1_Load(object sender, EventArgs e)
    {
         richTextBox1.SelectionBullet = true;
         richTextBox1.AcceptsTab = true;
    }
    
    private void richTextBox1_KeyUp(object sender, KeyEventArgs e)
    {
         if (e.KeyCode == Keys.Tab)
         {
              richTextBox1.SelectionIndent = 30;
         }
         if (e.KeyCode == Keys.Enter)
         {
              richTextBox1.SelectionIndent = 0;
         }
    }
