    private async void Form1_Load(Object sender, EventArgs e)
    {
        label1.Text = "0 %";
        var progress = new Progress<int>();
        progress.ProgressChanged += Progress_ProgressChanged;
        await DoWork(progress);
    }
    
    private void Progress_ProgressChanged(Object sender, Int32 e)
    {
        progressBar1.Value = e;
        double average = (double)e / ExtractImages.imagesUrls.Count();
        label1.Text = (average * 100).ToString() + " %";
    }
