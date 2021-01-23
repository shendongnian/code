    long bytesFromCompletedFiles = 0;
    private async void Completed(object sender, AsyncCompletedEventArgs e)
    {
        if (e.Cancelled == true)
        {
            MessageBox.Show("Download has been canceled.");
        }
        else
        {
            ProgressBar1.Value = 100;
            count++;
            bytesFromCompletedFiles = files[count - 1].Length;
            await DownloadFile();
        }
    }
