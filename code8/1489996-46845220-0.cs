    protected override async void OnNavigatingFrom(NavigatingCancelEventArgs e)
    {
        if (Current.HasModifications())
        {
            e.Cancel = true;
            await Current.Save().ContinueWith((t) =>
            {
                //Go Back after the Operation has finished
                Frame.GoBack();
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }
        else
        {
            base.OnNavigatingFrom(e);
        }
    }
