    private void gridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
    {
        if (e.Control.GetType() == typeof(DataGridViewComboBoxEditingControl))
        {
            ((ComboBox)e.Control).DropDownStyle = ComboBoxStyle.DropDown;
        }
    }
