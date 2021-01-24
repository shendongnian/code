		protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "CurrentPage")
			{
				var page = Element.CurrentPage as ContentPage;
				if (page != null)
				{
					//do what you want.
				}
			}
		}
