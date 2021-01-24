    private async void getDataFrmUrlButton_Click(object sender, EventArgs args)
    {
        using(var client = new WebClient())
        {
            string result = await client.DownloadStringTaskAsync(uri);
            // Do stuff with data
        }
    }
