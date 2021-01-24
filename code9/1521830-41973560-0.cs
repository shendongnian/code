    public async Task DownloadData()
    {
        string url = $"http://services.groupkt.com/country/get/all";
    
        HttpClient client = new HttpClient();
        client.DefaultRequestHeaders.Add("Accept", "application/json");
    
        string response = await client.GetStringAsync(url);
    
        dynamic json = JToken.Parse(response);
    
        foreach (var item in token.RestResponse.result)
        {
            //Note: Your over writing the text here for each item you pass
            //      Did you mean to concat instead? += "\n\r" + item.name;
            txtarea.InnerText = item.ToString();
        }
    }
