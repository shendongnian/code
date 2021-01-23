	private void btnreturn_Click(object sender, RoutedEventArgs e)
	{
		int gettext;
		int.TryParse(txtcount.Text, out gettext);
		Color Colorpicker; 
		   
		// Check if the SelectedColor is not null, and do stuff with it
		if (colorpicker.SelectedColor != null)
		{
			Colorpicker = (Color)colorpicker.SelectedColor;
			
			MainWindow win2 = new MainWindow(gettext, Colorpicker);
			win2.Show();
			Close();
		}
		else
		{
			// You didn't select a color... do something else
		}
	}
