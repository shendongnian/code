    private async Task<List<string>> GetWowAuctionFileInfo(string auctionInfoUri)
    {
        RealmJSFileCheck realmInfoObject;
        List<string> returnValue = new List<string>();
        try
        {
            using (HttpClient client = new HttpClient())
            {
                for (int attempt = 0; attempt < 3; attempt++)
                {
                    var response = await client.GetAsync(auctionInfoUri);
                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        realmInfoObject = JsonConvert.DeserializeObject<RealmJSFileCheck>(content);
                        // You can just return the List<T> now.
                        return ConvertFileInfoToConsumableList(realmInfoObject);
                        //returnValue = realmInfoObject.files.ToString();
                        break;
                    }
                }
            }
        }
        catch (InvalidOperationException iOpEx)
        {
           //recieved this when an invalid uri was passed in 
        }
    }
