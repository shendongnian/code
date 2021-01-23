	public class App : Application
	{
		public App()
		{
			var speechTextLabel = new Label
			{
				HorizontalTextAlignment = TextAlignment.Center,
				Text = "Waiting for text"
			};
			var speechButton = new Button();
			speechButton.Text = "Fetch Speech To Text Results";
			speechButton.Clicked += async (object sender, EventArgs e) =>
			{
				var speechText = await WaitForSpeechToText();
				speechTextLabel.Text = string.IsNullOrEmpty(speechText) ? "Nothing Recorded" : speechText;
			};
			var content = new ContentPage
			{
				Title = "Speech",
				Content = new StackLayout
				{
					VerticalOptions = LayoutOptions.Center,
					Children = {
						new Label {
							HorizontalTextAlignment = TextAlignment.Center,
							Text = "Welcome to Xamarin Forms!"
						},
						speechButton,
						speechTextLabel
					}
				}
			};
			MainPage = new NavigationPage(content);
		}
		async Task<string> WaitForSpeechToText()
		{
			return await DependencyService.Get<Listener.ISpeechToText>().SpeechToTextAsync();
		}
	}
