    private void dateTimePickerUntil_ValueChanged(object sender, EventArgs e)
    {
        if (dateTimePickerUntil.Value != untildate)
        {
            MessageBox.Show(dateTimePickerUntil.Value.ToString());
            if (dateTimePickerUntil.Value > DateTime.Today)
            {
                untildate = DateTime.Today; // Set first, so we can compare on the next event.
                dateTimePickerUntil.Value = DateTime.Today;
            }
            else
           {
              untildate = dateTimePickerUntil.Value;                
           }
       }
    }
   
