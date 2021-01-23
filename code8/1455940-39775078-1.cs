    async void StartCopy_Click(object sender, RoutedEventArgs e)
    {
        var progressDialog = new ProgressDialog();
        var progress = new Progress<int>(percent => progressDialog.Percent = percent);
        Task copyTask = DoCopyingAsync(progress);
        Task showProgressTask = progressDialog.ShowAsync();
        await copyTask;
        progressDialog.Hide();
        await showProgressTask;
    }
