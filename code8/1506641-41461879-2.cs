    private void comboBox2_TextUpdate(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(SelectJobComboBox.Text))
        {
            this.filteredItems.Clear();                
            SelectJobComboBox.DataSource = arrProjectList;
            SelectJobComboBox.DropDownHeight = 100; // select here how many items you want to be displayed
            SelectJobComboBox.DroppedDown = true;  // and force the combobox to open up
            Cursor.Current = Cursors.Default;
            SelectJobComboBox.SelectedIndex = -1;
        }
