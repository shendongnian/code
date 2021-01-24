    public async Task LoadData()
    {
        await Task.Run(() =>
        {
            var result = getDataFromDatabase();
            Application.Current.Dispatcher.Invoke(() => LstUsers = result);
        });
    }
