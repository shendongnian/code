	content.Appearing +=  (sender, e) =>
	{
		var pages = Application.Current.MainPage.Navigation.NavigationStack;
		foreach (var page in pages)
		{
			System.Diagnostics.Debug.WriteLine(page.Title);
		}
	};
