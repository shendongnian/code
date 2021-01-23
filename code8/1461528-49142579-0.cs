    	public async void OnLabelTapped(object sender, EventArgs args)
		{
			string mapUri = string.Empty;
			Label l = (Label)sender;
			mapUri = l.mapUri; 
			var result = await Application.Current.MainPage.DisplayAlert("Alert", "Launch Google Maps" , "OK", "Cancel");
			if (result)
			{
				Device.OpenUri(new Uri(mapUri));
			}
		}
