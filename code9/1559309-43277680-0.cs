    private void MyCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
		if (myCombobox.SelectedItem != null)
			if (myCombobox.SelectedItem.ToString().Equals("Test1"))
			{
				testGrid.Visibility = Visibility.Visible;
			}
			else if (myCombobox.SelectedItem.ToString().Equals("Test2") || myCombobox.SelectedItem.ToString().Equals("Test3"))
			{
				testGrid.Visibility = Visibility.Hidden;
			}
		}
    }
