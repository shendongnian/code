	var waitHandle = new EventWaitHandle(false, EventResetMode.AutoReset);
	var modalPage = new ContentPage();
	modalPage.Disappearing += (sender2, e2) =>
	{
		waitHandle.Set();
	};
	await content.Navigation.PushModalAsync(modalPage);
	System.Diagnostics.Debug.WriteLine("The modal page is now on screen, hit back button");
	await Task.Run(() => waitHandle.WaitOne());
	System.Diagnostics.Debug.WriteLine("The modal page is dismissed, do something now");
