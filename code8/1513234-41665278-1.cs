    private void BtnReadFileContent_OnClick(object sender, RoutedEventArgs e)
    {
        Task.Run(() => _sourceService.ReadFileContent(filePath)) //<- this will run on a background thread
            .ContinueWith(task =>
            {
                //...and this will run back on the UI thread once the task has finished
                dataGrid.ItemsSource = dt.DefaultView;
                if (dt.Rows.Count > 0)
                    BtnCreateXmlFile.IsEnabled = true;
            }, System.Threading.CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
    }
