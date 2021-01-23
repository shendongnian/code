    Text = ((ComboBoxItem)Choice.SelectedItem).Content.ToString();
    
    or
    
    var comboBoxItem = Choice.Items[Choice.SelectedIndex] as ComboBoxItem;
    if (comboBoxItem != null)
    {
        string selectedcmb = comboBoxItem.Content.ToString();
    }
