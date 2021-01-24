    private void DisbursalDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
    {
        foreach (ScriptDTO person in RadGridView1.Items.OfType<ScriptDTO>())
        {
            if (person.Date <= DisbursalDatePicker.SelectedDate)
            {
                person.SetError("Date", "Must be after disbursal");
            }
            else
            {
                person.ClearErrors();
            }
        }
    }
