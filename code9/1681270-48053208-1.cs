    // In ScannerPage
    protected override void OnAppearing ()
	{
	    base.OnAppearing ();
	    MessagingCenter.Subscribe<ScannerPage,string>(this, "eventName", (sender,label) => {
	        // do something whenever the message is sent
	        Device.BeginInvokeOnMainThread (() => {
	           MyScannerPageViewModel.SetLabel(label);
	        });
	    });
	}
	protected override void OnDisappearing ()
	{
	    base.OnDisappearing ();
	    MessagingCenter.Unsubscribe<ScannerPage,string> (this, "eventName");
	}
