    private async void Completed(object sender, AsyncCompletedEventArgs e)
    {
        // urlCount will be decremented
        // cnt will get its value
        var cnt = System.Threading.Interlocked.Decrement(ref urlCount);
        if (cnt > 0) {
            await DownloadFile();
        } 
        else
        {
            // call here what ever you want to happen when everything is 
            // downloaded
            "Done".Dump();
        }
    }
