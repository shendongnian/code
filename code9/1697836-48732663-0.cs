    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        int parsed = 0;
        if (!int.TryParse(textBox1.Text), out parsed)
        {
            MessageBox.Show("No. You must enter a number!");
            return;
        }
        if (parsed > 100)
        {
            MessageBox.Show("No. Of Elements Must be Less Then 100");
        }
    }
