    private void cboMyComboBox_DropDown(object sender, EventArgs e)
    {
        // The first time that the combo box is activated, remove the initial item
        if (viewModel.ComboOptions[0].ToString() == String.Empty)
            viewModel.ComboOptions.RemoveAt(0);                       
    }
