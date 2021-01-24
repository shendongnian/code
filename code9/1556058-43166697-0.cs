    public string RandomImage()
    {
        string result = null;
        var apiurl = "http://random.cat";
        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri(apiurl);
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        HttpResponseMessage ResponseMessage = client.GetAsync(apiurl + "/meow").Result; // The .Result part will make this method not async
        if (ResponseMessage.IsSuccessStatusCode)
        {
            var ResponseData = ResponseMessage.Content.ReadAsStringAsync().Result;
            var MyRandomImage = JsonConvert.DeserializeObject<RandomImage>(ResponseData);
            result = MyRandomImage.file; // This is the url for the file
        }
        // Return
        return result;
    }
