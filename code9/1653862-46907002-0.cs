    string[] values = new string[18];
    
    int count = 0;
    foreach (Panel p in panels)
    {
        //ALWAYS 9 * (2 values) panels.
        var selectedRadioButton = p.Controls.OfType<RadioButton>().FirstOrDefault(rb => rb.Checked);
        if (selectedRadioButton != null)
        {
            values[i] = selectedRadioButton.Name;
            values[i+1] = selectedRadioButton.Text;
        }
    
        count+=2;
    }
