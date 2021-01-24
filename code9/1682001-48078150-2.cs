    async void Handle_Refreshing(object sender, System.EventArgs e)
    {
        _footmarks = new ObservableCollection<Footmark>(await GetFootMarksAsync());
        listView.ItemsSource = _footmarks;
        listView.EndRefresh();
    }
