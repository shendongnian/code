	private void cbAdditionalFields_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		// ... Get the ComboBox.
		var comboBox = sender as ComboBox;
		//string value = comboBox.SelectedItem as string;
		UserField value = comboBox.SelectedItem as UserField;
        Console.WriteLine(value.Name);
	}
