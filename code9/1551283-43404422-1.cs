    private bool _isWorking;
    private async void LineTrackListView_SelectionChangedAsync(object sender, SelectionChangedEventArgs e)
    {
        if (_isWorking)
        {
            return;
        }
        _isWorking = true;
        // Removed some of your code here.
        listView.SelectedItem = -1;
        await Task.Delay(100);
        ChangePageToBusPage(selectedBusStopInListView.BusStop, selectedTrack);
        _isWorking = false;
    }
