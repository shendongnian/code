    private async void GetHomeItems()
    {
        var client = new HttpClient();
        var url = new Uri(IAMSUrl + "/GetProductSRP");
        var content = new StringContent("{CustomerCode: 'test'}");
    
        var response = await client.PostAsync(url, content);
        //As string
        var result = await response.Content.ReadAsStringAsync();
        //As Object
        var objResult = JsonConvert.DeserializeObject<SrpResult>(result);
    DataTable dt = (DataTable)JsonConvert.DeserializeObjectt<SrpResult>(objResult.toString(), (typeof(DataTable)));
    }
