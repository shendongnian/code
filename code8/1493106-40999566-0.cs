	private async Task GetAuctionData()
	{
		List<Task> tasks = new List<Task>();
		using (var client = new HttpClient())
		{
			for (int i = 0; i < dataGridView1.Rows.Count; i++)
			{
				var downloadTask = Task.Run(() =>
					{
						// Perform work here on HttpClient
					});
				tasks.Add(downloadTask);
			}
			await Task.WhenAll(tasks);
		}
	}
