	[TestMethod]
	public async Task NeverCompletes()
	{
		using (var apartment = new MessageLoopApartment())
		{
			// create a form inside MessageLoopApartment
			var form = apartment.Invoke(() => new Form {
				Width = 400, Height = 300, Left = 10, Top = 10, Visible = true });
			try
			{
				// await outside MessageLoopApartment's thread
				await Task.Delay(2000);
				await apartment.Run(async () =>
				{
					// this runs on MessageLoopApartment's STA thread 
					// which stays the same for the life time of 
					// this MessageLoopApartment instance
					form.Show();
					await Task.Delay(1000);
					form.BackColor = System.Drawing.Color.Green;
					await Task.Delay(2000);
					form.BackColor = System.Drawing.Color.Red;
					await Task.Delay(3000);
				}, CancellationToken.None);
			}
			finally
			{
				// dispose of WebBrowser inside MessageLoopApartment
				apartment.Invoke(() => form.Dispose());
			}
		}
	}
