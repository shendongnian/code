    private void textBox2_TextChanged(object sender, EventArgs e)
    {
        if (textBox2.Text.Last() == ',')
        {
            for (int i = 0; i < data.Count; i++)
            {
                data[i] = textBox2.Text + data[i];
            }
        }
    }
