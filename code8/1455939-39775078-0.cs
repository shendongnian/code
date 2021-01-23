    async void StartCopy_Click(object sender, RoutedEventArgs e)
    {
        var progressDialog = new ProgressDialog();
        var progress = new Progress<int>(percent => progressDialog.Percent = percent);
        await Task.WhenAll(DoCopyAsync(progress), progressDialog.ShowAsync());
    }
