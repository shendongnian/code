    private void onATSRadComboBoxSelectedItemChangedCommand(object obj)
    {
        try
        {
            RadComboBox atsRadComboBox = obj as RadComboBox;
            if (atsRadComboBox.SelectedValue == null) return;
            string  selectedValue= atsRadComboBox.SelectedValue.ToString();
            if (selectedValue.Trim() != string.Empty)
            {
                BindAtsData(Convert.ToInt32(selectedValue));
            }
        }
        catch (Exception ex)
        {
            customerAC.LogFile(ex.ToString());
        }
    }
