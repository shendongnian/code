	void Handle_Clicked(object sender, System.EventArgs e)
	{
		foreach (var child in ((sender as Button).Parent as StackLayout).Children)
		{
			if (child is Button && !child.Equals(sender))
			{
				child.IsEnabled = false;
			}
		}
	}
