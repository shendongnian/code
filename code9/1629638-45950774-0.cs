    // Register the checked changed event and point all to the same event handler
    checkBox1.CheckedChanged += CheckBox_CheckedChanged;
    checkBox2.CheckedChanged += CheckBox_CheckedChanged;
    checkBox3.CheckedChanged += CheckBox_CheckedChanged;
    
    private void CheckBox_CheckedChanged(object sender, EventArgs e)
    {
        if (sender is CheckBox == false) return;
    
        var currentCheckBox = (CheckBox) sender;
    
        foreach (var checkBox in this.Controls.OfType<CheckBox>().Where(a => a != currentCheckBox))
        {
            checkBox.Checked = currentCheckBox.Checked;
        }
    }
