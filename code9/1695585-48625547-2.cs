    void Button_Click(object sender, EventArgs e)
    {
        // since this is a UI event, instantiating the Progress class
        // here will capture the UI thread context
        var progress = new Progress<int>(i => progressBar1.Value = i);
            
        // pass this instance to the background task
        Task.Run(() => ReportWithProgress(progress));
    }
    async Task ReportWithProgress(IProgress<int> p)
    {
        for (int i = 0; i <= 100; i++)
        {
            await Task.Run(() => HeavyIO());
            Console.WriteLine("Progress : " + i);
            p.Report(i);
        }
    }
