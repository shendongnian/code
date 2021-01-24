    	protected override async void OnNavigatedTo(NavigationEventArgs e)
		{
			if (await AuthenticateAsync())
			{
				ButtonRefresh_Click(this, null);
			}
		}
