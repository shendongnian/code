    private async void Form1_Load(Object sender, EventArgs e)
    {
        label1.Text = "0 %";
        var progress = new Progress<int>();
        progress.ProgressChanged += Progress_ProgressChanged;
        await DoWork(progress);
    }
    
    private void Progress_ProgressChanged(Object sender, Int32 e)
    {
         progressBar1.Value = e + 1;
         double average = ((double)(e + 1) / (ExtractImages.imagesUrls.Count()));
         label3.Text = (Math.Round(average, 1) * 100).ToString() + " %";
    }
