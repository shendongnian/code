    private async Task ReportWithProgress()
    {
        var p = new Progress<int>(i => progressBar1.Value = i);
    	p.ProgressChanged += (s, e) => progressBar2.Value = e;
    
        for (int i = 0; i <= 100; i++)
        {
            await Task.Run(() => HeavyIO()); 
            Console.WriteLine("Progress : " + i);
            ((IProgress<int>)p).Report(i);
        }
    }
