    private bool IsComboBoxSameValue()
    {
        if(ComboBox1.SelectedItem.ToString() == ComboBox2.SelectedItem.ToString()
        {
            MessageBox.Show("The ComboBoxes have the same value");
            return true; // the ComboBoxes has the same value
        }
        else
        {
            return false; // the comboboxes has different value
        }
    }
