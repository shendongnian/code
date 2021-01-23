    private void btnSync_Click(object sender, EventArgs e)
    {
         // Set title bar to selected date.
         DateTime dtToBeSet = dateTimePicker1.Value;
         SetSystemDateTime(dtToBeSet);
    }
