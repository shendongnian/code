    public static async void Main(string[] args)
    {
        var urlAddress = "http://mywebsite.com/msexceldoc.xlsx";
        var fileName = @"D:\1.xlsx";
        using (var client = new WebClient())
        {
            await client.DownloadFileTaskAsync(new Uri(urlAddress), fileName);
        }
    }
