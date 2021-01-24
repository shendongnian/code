      	void OnClicked(object sender, System.EventArgs e)
		{
			var btn = sender as Button;
			MessagingCenter.Send(this, "ThemeButtonClicked", btn.BackgroundColor);
			Application.Current.Properties["Theme"] = btn.BackgroundColor;
			Application.Current.SavePropertiesAsync();
			Navigation.PopAsync(true);
		}
