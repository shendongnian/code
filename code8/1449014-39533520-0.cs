    private void Form1_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            e.SuppressKeyPress = true;
            this.BeginInvoke(new Action(() => {
                if (textBox.Text.Length > 10)
                    MessageBox.Show("Test");
            }));
        }
    }
