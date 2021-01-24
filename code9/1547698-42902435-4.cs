	public void SetButtonVisibility(bool visible)
	{
		if (scroll_viewer == null) return;
		if (visible)
		{
			scroll_left_button.Visibility = Visibility.Visible;
			scroll_right_button.Visibility = Visibility.Visible;
		}
		else
		{
			scroll_left_button.Visibility = Visibility.Collapsed;
			scroll_right_button.Visibility = Visibility.Collapsed;
		}
	}
