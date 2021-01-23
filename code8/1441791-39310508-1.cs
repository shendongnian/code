    public async Task DoStuffAsync()
    {
        var result = await DownloadFromWebpageAsync(); //calls method and waits till execution finished
        var task = WriteTextAsync(@"temp.txt", result); //starts saving the string to a file, continues execution right await
        Debug.Write("this is executed parallel with WriteTextAsync!"); //executed parallel with WriteTextAsync!
        await task; //wait for WriteTextAsync to finish execution
    }
    
    private async Task<string> DownloadFromWebpageAsync()
    {
        using (var client = new WebClient())
        {
            return await client.DownloadStringTaskAsync(new Uri("http://stackoverflow.com"));
        }
    }
    
    private async Task WriteTextAsync(string filePath, string text)
    {
        byte[] encodedText = Encoding.Unicode.GetBytes(text);
    
        using (FileStream sourceStream = new FileStream(filePath, FileMode.Append))
        {
            await sourceStream.WriteAsync(encodedText, 0, encodedText.Length);
        }
    } 
