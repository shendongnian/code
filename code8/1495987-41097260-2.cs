    private void textBox1_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyValue == 13 && !e.Shift)
        {
            if (!textBox1.AcceptsReturn && !string.IsNullOrEmpty(textBox1.Text))
            {
                button1.PerformClick();
                textBox1.Text = "";
                e.Handled = true;
            }
        }
    }
