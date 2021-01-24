    private void FormLoadComplete(object parameter)
    {
        IsBusy = true;
        Dispatcher.Invoke(() => {
            LoadData();
            IsBusy = false;
        });
    }
