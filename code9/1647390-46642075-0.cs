	private void tc_selectionChanged(object sender, SelectionChangedEventArgs e)
	{
		if (ti1.IsSelected)
		{
			txt.Focus();
		}
		else if (ti2.IsSelected)
		{
			dg.Focus();
		}
	}
