    private void GoDownload(Download Dnld, string[] urllist, EventArgs e) 
    {
        foreach(string url in urllist) 
        {
            Dnld.Dnld(url);
            // this is just to give more time to test the cancellation
            System.Threading.Thread.Sleep(500);
            // Check the cancellation after each download
            if (DnldBgWorker.CancellationPending) 
            {
                e.Cancel = true;
                return;
            }
        }
    }
