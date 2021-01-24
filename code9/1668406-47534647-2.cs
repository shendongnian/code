    private async void Btn_Click()
    {
        TextBlock1.Text = "Work started."
        await DoWork();
        TextBlock1.Text = "Work done."
    }
    private async Task DoWork()
    {
        myTextBlock2.Text = "Requesting html from the web.";
        HttpClient _httpClient = new HttpClient();
        string data = await _httpClient.GetStringAsync("example.com/stringdata.html");
        //here the function stops executing, and doesn't continue until GetStringAsync returns a value. 
        //While this, it gives back control to the callee (AKA the UI thread, so it doesn't block it, 
        //and can process data like mouse movement, and textblock text changes.)
        myTextBlock2.Text = "Processing data";
        string outputData = await Task.Run(() => HighCPUBoundWork(data));
        
        //The CPU bound work doesn't block the UI thread, because we created a new thread for it.
        //When it completes, we continue.
        myTextBlock2.Text = "Writing output data to file";
        using (StreamWriter writer = File.CreateText("output.txt"))
        {
            await writer.WriteAsync(outputData);
            //Same thing applies here, we are waiting for the OS to write to the specified file, 
            //and while it is doing that, we can get back to the UI.
        }
    }
    private string HighCPUBoundWork(string data)
    {
        //Here you can do some high cpu intensity work, like computing PI to the 1000000000th digit, or anything.
        //The html files processing would be more likely tho.. :)
        //Notice, that this function is not async.
        return modifiedInputData;
    }
