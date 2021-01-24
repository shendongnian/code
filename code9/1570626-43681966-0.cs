		private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
		{
			// this is where you would enable your indicator
			Button.IsEnabled = false;
			await Task.Run(
				() =>
				{
					// this is where you put your work, which should be executed in the background thread.
					Thread.Sleep(2000);
				});
			// this is where you would disable it
			Button.IsEnabled = true;
		}
