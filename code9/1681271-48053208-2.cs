    // In ScannerPage
    protected override void OnAppearing ()
	{
	    base.OnAppearing ();
	    MessagingCenter.Subscribe<string>(this, "eventName", (label) => {
	        // do something whenever the message is sent
	        Device.BeginInvokeOnMainThread (() => {
	           MyScannerPageViewModel.SetLabel(label);
	        });
	    });
	}
	protected override void OnDisappearing ()
	{
	    base.OnDisappearing ();
	    MessagingCenter.Unsubscribe<string> (this, "eventName");
	}
