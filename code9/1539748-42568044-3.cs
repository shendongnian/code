    private async void btnPopulate_Click(object sender, RoutedEventArgs e)
    {
        for (int n = 0; n < 100; n++)
        {
            // simulates one of several (e.g. 100) asynchronous operations
            await Task.Delay(50);
            // periodically, update the progress
            _viewModel.ProgressValue = n;
        }
    }
