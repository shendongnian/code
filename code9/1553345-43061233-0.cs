    private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
            {
                if (e.KeyChar == Convert.ToChar(Keys.Enter) || e.KeyChar == Convert.ToChar(Keys.Space))
                {
                    button1_Click(sender, e);
                }
            }
