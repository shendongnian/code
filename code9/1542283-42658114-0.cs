    int i;
    var checkedButton = groupBox1.Controls
                    .OfType<RadioButton>()
                    .FirstOrDefault(rb => rb.Checked);            
    if (int.TryParse(checkedButton.Tag.ToString(), out i))
    {
        // here's your value 
    }
