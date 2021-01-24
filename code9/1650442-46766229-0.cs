		private async void LaunchButton_OnClick(object sender, RoutedEventArgs e)
		{
			resultLabel.Content = "Task running";
			resultLabel.Content = await SomeLongRunningTaskAsync();
		}
		private Task<string> SomeLongRunningTaskAsync()
		{
			return Task.Run(
				() =>
				{
					// Put your background work in here. with Task.Run it's not going to run on UI 
					int count = 0;
					while (count < 1000)
					{
						count++;
						Thread.Sleep(10);
					}
					return "Task done";
				});
		}
