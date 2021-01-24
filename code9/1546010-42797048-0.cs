    private void majorComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (majorComboBox.SelectedIndex == 0)
        {
             courseListBox.Items.Add("Computer Science");
        }
        if (majorComboBox.SelectedIndex == 1)
        {
            courseListBox.Items.Add("Business");
        }
    }
