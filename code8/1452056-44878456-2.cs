    protected override void OnAppearing()
    {
        base.OnAppearing();
        var pageOnTop = ModalContentPageOnTop();
        if (pageOnTop == null || pageOnTop == this)
        {
            // do some stuff, like setting up subscriptions
            SetupSubscriptions();
        }
        else
        {
            // Xamarin Forms Appearing/Disappearing Bug
            // Found that when you leave the Android app with a modal page on top of a non-modal page (either minimise the app or lock the device), then Xamarin.Forms does not properly call OnAppearing. 
            // Xamarin.Forms will call OnAppearing on the non-modal page and not on the modal page. This would not only cause message subscriptions to not be set up on the modal page, 
            // but would also set up message subscriptions on the non-modal page. Not good.  Hopefully, this work-around should stop being executed when Xamarin fixes the problem, as we won't 
            // fall into this "else" condition above, because OnAppearing will be called on the right page.
            // NOTE: SendDisappearing and SendAppearing have boolean guards on them. If SendAppearing was called last, calling it again will do nothing.
            // SendDisappearing has the same behaviour. Thus we need to call SendDisappearing first, to be guaranteed that SendAppearing will cause the OnAppearing() method to execute.
	        ((IPageController)pageOnTop).SendDisappearing();  // try and correct Xamarin.Forms - the page actually on top was not told it was disappearing - tell it now
	        ((IPageController)this).SendDisappearing();  // try and correct Xamarin.Forms - if it thinks the view has appeared when it hasn't, it won't call OnAppearing when it is truly appearing.
	        ((IPageController)pageOnTop).SendAppearing();  // try and correct Xamarin.Forms by notifying the correct page that it is appearing
        }
    }
