    private void dateTimePicker1_Validating(object sender, CancelEventArgs e)
    {
        if (dateTimePicker1.Value < DateTime.Today)
        {
            MessageBox.Show("You can't choose this date!");
            e.Cancel = true;
        }
    }
