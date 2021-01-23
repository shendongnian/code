    private async Task<IList<SomeDataItem> GetDataItemsAsync()
    {
        // do some work in background, e.g. call web service or database
        // ...
        return dataItems;
    }
    
    pirvate async void HandleRefreshButtonClick(object sender, EventArgs e)
    {
        var dataItems = await GetDataItemsAsync();
    
        // since we didn't call ConfigureAwait(false) for task,
        // the rest of method will run on UI thread
        bindingList.Clear();
    
        foreach (var item in dataItems)
        {
            bindingList.Add(item);
        }
    }
