	button.Click += (object sender, System.EventArgs e) =>
	{
		Task.Run(async () =>
		{
			RunOnUiThread(() => txt.Text = "Connecting...");
			await Task.Delay(2500); // Simulate SQL Connection time
            
			if (sql.testConnection())
			{
				RunOnUiThread(() => txt.Text = "Connected...");
				await Task.Delay(2500); // Simulate SQL Load time
				//load();
			}
			else
				RunOnUiThread(() => txt.Text = "SQL Connection error");
		});
	};
