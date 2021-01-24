    private int pageIndex = 0;
    private string address = @"http://www.test.com?page={0}";
    private async void GetPreviousPageContent()
    {
        pageIndex--;
        Uri uri = new Uri(string.Format(address,pageIndex));
        HttpClient client = new HttpClient();
        var response = await client.GetAsync(uri);
    }
    private async void GetNextPageContent()
    {
        pageIndex++;
        Uri uri = new Uri(string.Format(address, pageIndex));
        HttpClient client = new HttpClient();
        var response = await client.GetAsync(uri);
    }
