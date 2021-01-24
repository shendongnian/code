    try {
        DateTime DateOfBirth = new DateTime((int)comboBoxYear.SelectedItem, comboBoxMonth.SelectedIndex + 1, (int)comboBoxDay.SelectedItem);
        TimeSpan diff = DateTime.Now - DateOfBirth;
        int AgeInDays = (int)diff.TotalDays;
        MessageBox.Show(textBoxName.Text + " you are " + (AgeInDays.ToString()) + " Days Old");
    }
    catch (InvalidCastException)
    {
        MessageBox.Show("Wrong Format");
    }
