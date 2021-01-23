	// Note this is void because I'm assuming it's an event handler. 
	// If it isn't this should be `async Task` instead.
	public async void FindCustomersAsync()
	{
		txtEmailCount.Text = "Loading";
		await Task.Run(() => FindCustomersForEmail(reg.Index));
		
		txtEmailCount.Text = customersToEmail.Rows.Count.ToString();
	}
	
