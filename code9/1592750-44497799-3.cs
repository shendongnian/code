    private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(ComboBox.SelectedIndex != -1)
        {
            MainTextBox.Text = ComboBox.SelectedValue.ToString();
            ComboBox.SelectedIndex = -1;
        }
    }
