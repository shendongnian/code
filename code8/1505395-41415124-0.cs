    async void OnCreate()
    {
        // Some code (get references to views, etc.)
    
        progressView.Visibility = ViewStates.Visible;
    
        var asyncResult = await SomeAsyncOperation();
    
        progressView.Visibility = ViewStates.Gone;
    
        // Some more code
    }
