	void IPageController.SendAppearing()
	{
		if (_hasAppeared)
			return;
		_hasAppeared = true;
		if (IsBusy)
			MessagingCenter.Send(this, BusySetSignalName, true);
		OnAppearing();
		EventHandler handler = Appearing;
		if (handler != null)
			handler(this, EventArgs.Empty);
		var pageContainer = this as IPageContainer<Page>;
		((IPageController)pageContainer?.CurrentPage)?.SendAppearing();
    }
