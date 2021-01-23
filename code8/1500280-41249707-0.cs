    private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
    {
        if (e.Control is ComboBox)
        {
            ComboBox cmCombo = e.Control as ComboBox;
            cmCombo.DropDownStyle = ComboBoxStyle.DropDown;
            cmCombo.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmCombo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        }
    }
    private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            string value = cbCombo.Value.ToString();
        }
     }
