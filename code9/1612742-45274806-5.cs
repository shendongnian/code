    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await Task.Delay(500);
        var content = this.Content as StackLayout;
        content.Children.Add(new SearchPage());
    }
    
    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        var content = this.Content as StackLayout;
        foreach (var child in content.Children)
        {
            var searchpage = child as SearchPage;
            if (searchpage != null)
            {
                content.Children.Remove(searchpage);
                return;
            }
        }
    }
