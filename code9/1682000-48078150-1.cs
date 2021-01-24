    protected override async void OnAppearing()
    {
        _footmarks = new ObservableCollection<Footmark>(await GetFootMarksAsync());
        listView.ItemsSource = _footmarks;
        base.OnAppearing();
    }
