    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        if (e.Parameter is string && !string.IsNullOrWhiteSpace((string)e.Parameter))
        {
            var menuitemvalue = e.Parameter as string;
        }
        else
        {
            
        }
        base.OnNavigatedTo(e);
    }
