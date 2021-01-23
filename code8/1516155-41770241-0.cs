    textBox1.Text = myReader["Surname"].ToString();
    textBox2.Text = myReader["FirstName"].ToString();
    textBox3.Text = myReader["MI"].ToString();
    textBox4.Text = myReader["Sex"].ToString();
    textBox7.Text = myReader["Age"].ToString();
    textBox9.Text = myReader["Area"].ToString();
    trySetDateTimePickerValue(myReader["Born"], dateTimePicker1);
    trySetDateTimePickerValue(myReader["Died"], dateTimePicker2);
    trySetDateTimePickerValue(myReader["Interment"], dateTimePicker3);
    
    // ...
    
    public void trySetDateTimePickerValue(DateTimePicker dateTimePicker, SomeTypeOfReader reader)
    {
        if (reader != null)
        {
            string cleanDate = reader.ToString().Trim(); 
            if (cleanDate.Length > 0) // maybe this trim/test is overkill, maybe the TryParse below is sufficient
            {
                DateTime parsedDate = DateTime.MinValue;
                if (DateTime.TryParse(cleanDate, out parsedDate)
                {
                    dateTimePicker.Value = parsedDate;
                    return; // success - exit method
                }
            }
        }
    
        // no valid date in string:
        // this is the default value if no value is set according to MSDN
        dateTimePicker.Value = DateTime.Now;
    
        // show nothing in the picker (not sure if this is good solution, this is what the original code does)
        dateTimePicker.Format = DateTimePickerFormat.Custom;
        dateTimePicker.CustomFormat = " ";
    
    }
