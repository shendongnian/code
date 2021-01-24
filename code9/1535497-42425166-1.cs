	private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		comboBox.Items.Refresh();
		var value = (sender as ComboBox).SelectedItem; // Tested using short? with same result
		var x = TNumber;
	}
