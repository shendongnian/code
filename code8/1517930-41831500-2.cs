    private void CheckComboBoxes(object sender, EventArgs e)
    {
    	List<string> comboValues = new List<string>();
    	foreach (Control c in this.Controls)
    	{
    		if (c is ComboBox && !string.IsNullOrEmpty((c as ComboBox).SelectedItem.ToString()))
    		comboValues.Add((c as ComboBox).SelectedItem.ToString());
    	}
    	if (comboValues.Distinct().ToList().Count < comboValues.Count)
    		MessageBox.Show("not all combos are unique");
    }
