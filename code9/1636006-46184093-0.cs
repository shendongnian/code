	private void Button_Tapped(object sender, TappedRoutedEventArgs e)
	{
		var page = ((FrameworkElement)myControl.Parent).Parent;
		if (page.GetType() == typeof(MainPage))
		{
			(page as MainPage).ShowData();
		}
	}
