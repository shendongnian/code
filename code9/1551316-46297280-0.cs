    public void ToggleButtonChecked(object sender, RoutedEventArgs e)
		{
			ToggleButton btn = sender as ToggleButton;
			if (btn == null)
				return;
			Panel container = btn.Parent as Panel;
			if (container == null)
				return;
			for (int i = 0; i<container.Children.Count; i++)
			{
				if (container.Children[i].GetType() == typeof(ToggleButton))
				{
					ToggleButton item = (ToggleButton)container.Children[i];
					if (item != btn && item.IsChecked == true)
						item.IsChecked = false;
				}
			}
		}
