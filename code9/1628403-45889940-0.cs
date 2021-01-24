    private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (textBox2 != null) textBox2.IsEnabled = textBox1.Text.Length == 0;
    }
    private void textBox2_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (textBox1 != null) textBox1.IsEnabled = textBox2.Text.Length == 0;
    }
