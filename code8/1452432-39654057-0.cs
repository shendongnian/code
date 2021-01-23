	var modalPage = new ContentPage();
	modalPage.Disappearing += (sender2, e2) =>
	{
		System.Diagnostics.Debug.WriteLine("The modal page is dismissed, do something now");
	};
	await content.Navigation.PushModalAsync(modalPage);
	System.Diagnostics.Debug.WriteLine("The modal page is now on screen, hit back button");
