    private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
    {
        // Calculate download speed and output it to labelSpeed.
        Label2.Text = string.Format("{0} kb/s", (e.BytesReceived / 1024d / sw.Elapsed.TotalSeconds).ToString("0.00"));
        // Update the progressbar percentage only when the value is not the same.
        double bytesInCurrentDownload = double.Parse(e.BytesReceived.ToString());
        double totalBytesCurrentDownload = double.Parse(e.TotalBytesToReceive.ToString());
        double percentageCurrentDownload = bytesInCurrentDownload / totalBytesCurrentDownload * 100;
        ProgressBar1.Value = int.Parse(Math.Truncate(percentageCurrentDownload).ToString());//e.ProgressPercentage;
                                                                             // Show the percentage on our label.
        Label4.Text = e.ProgressPercentage.ToString() + "%";
        // Update the label with how much data have been downloaded so far and the total size of the file we are currently downloading
        Label5.Text = string.Format("{0} MB's / {1} MB's",
            (e.BytesReceived / 1024d / 1024d).ToString("0.00"),
            (e.TotalBytesToReceive / 1024d / 1024d).ToString("0.00"));
        //Let's update ProgressBar2
        double totalBytesDownloaded = e.BytesReceived + bytesFromCompletedFiles;
        double percentageTotalDownload = totalBytesDownloaded / totalBytesToDownload * 100;
        ProgressBar2.Value = int.Parse(Math.Truncate(percentageTotalDownload)).ToString();
    }
