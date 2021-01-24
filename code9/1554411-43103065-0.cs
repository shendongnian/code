    private void buttonDaysOld_Click(object sender, EventArgs e)
    {
        DateTime DateOfBirth;
        try
        {
            DateOfBirth = new DateTime((int)comboBoxYear.SelectedItem, comboBoxMonth.SelectedIndex + 1, (int)comboBoxDay.SelectedItem);
        }
        catch (Exception exception)
        {
            MessageBox.Show(exception.Message);
            return;
        }
        TimeSpan diff = DateTime.Now - DateOfBirth;
        int AgeInDays = (int)diff.TotalDays;
        MessageBox.Show(textBoxName.Text + " you are " + (AgeInDays.ToString()) + " Days Old");
    }
