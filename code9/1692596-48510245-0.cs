    protected void TextBox12_TextChanged(object sender, EventArgs e)
    {
        if (ListBox1.SelectedItem != null && ListBox1.SelectedItem.Text == "Other")
        {
            ListBox1.SelectedItem.Text = TextBox12.Text;
        }
    }
