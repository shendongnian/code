	private void all_Checked(object sender, RoutedEventArgs e)
	{
	   issue.IsChecked = true;
	   summary.IsChecked = true;
	   type.IsChecked = true;
	   status.IsChecked = true;
	   label.IsChecked = true;
	   components.IsChecked = true;
	   empty.IsChecked = true;
	   reporter.IsChecked = true;
	   requester.IsChecked = true;
	   team.IsChecked = true;
	   assignee.IsChecked = true;
	}
	
	private void all_Unchecked(object sender, RoutedEventArgs e)
	{
		issue.IsChecked = false;
		summary.IsChecked = false;
		type.IsChecked = false;
		// You get the rest.
	}
	
