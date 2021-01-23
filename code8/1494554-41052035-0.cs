    private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                label1.Text = ("text inserted");
            }
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            KeyEventArgs ev = new KeyEventArgs(Keys.Enter);
            textBox1_KeyDown(sender, ev);
        }
