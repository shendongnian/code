	int newViewId = 0;
	Window SecondWindow;
	private async void Button_Click_NewWindow(object sender, TappedRoutedEventArgs e)
	{
		string TextBoxText = Textblock1.Text;
		int mainViewId = ApplicationView.GetApplicationViewIdForWindow(CoreApplication.MainView.CoreWindow);
		if (newViewId == 0)
		{
			CoreApplicationView newCoreView = CoreApplication.CreateNewView();
			ApplicationView newAppView = null;
			await newCoreView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
			{
				newAppView = ApplicationView.GetForCurrentView();
				Window.Current.Content = new Frame();
				(Window.Current.Content as Frame).Navigate(typeof(SecondPage), TextBoxText);
				Window.Current.Activate();
				SecondWindow = Window.Current;
			});
			newViewId = newAppView.Id;
		}
		else
		{
			await SecondWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
			{
				SecondWindow.Content = new Frame();
				(SecondWindow.Content as Frame).Navigate(typeof(SecondPage), TextBoxText);
				SecondWindow.Activate();
			});
		}
		await ApplicationViewSwitcher.TryShowAsStandaloneAsync(newViewId, ViewSizePreference.UseHalf, mainViewId, ViewSizePreference.UseHalf);
	}
