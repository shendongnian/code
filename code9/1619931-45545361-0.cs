    public void loadtest(BackgroundWorker bw)
    {
        //... your code
        q1.BeginInit();
        q1.StreamSource = mstreamq1;
        q1.CacheOption = BitmapCacheOption.OnLoad;
        q1.EndInit();
        // Don't directly assign the Source property of your image
        // q_image.Source = q1;
        // Instead, report progress to the UI thread:
        bw.ReportProgress.ReportProgress(25, new Tuple<Image, ImageSource>(q_image, q1));
        //... your code
    }
    private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        pop.prgTest.Value = e.ProgressPercentage;
        // assign the image source on the UI thread
        var data = e.UserState as Tuple<Image, ImageSource>;
        data.Item1.Source = data.Item2;
    }
