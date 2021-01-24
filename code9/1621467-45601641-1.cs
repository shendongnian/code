    private void comboBox1_TextChanged(object sender, EventArgs e)
    {
        if (comboBox1.Text.Any(x => !char.IsDigit(x)))
        {
            comboBox1.Text = string.Concat(comboBox1.Text.Where(char.IsDigit));
            comboBox1.Select(comboBox1.Text.Length, 0);
        }
    }
