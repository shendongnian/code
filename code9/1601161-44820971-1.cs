        public async void CallApi(Object stateInfo)
    {
        var client = new HttpClient();
        var requestContent = new FormUrlEncodedContent(new[] { new KeyValuePair<string, string>("pair", "XETHZEUR"), });
        HttpResponseMessage response = await client.PostAsync("https://api.kraken.com/0/public/Trades", requestContent);
        HttpContent responseContent = response.Content;
        using (var reader = new StreamReader(await responseContent.ReadAsStreamAsync()))
        {
            String result = await reader.ReadToEndAsync();
            //Here I would like to do a JSON Convert of my variable result
            var yourObject = JsonConvert.DeserializeObject(result);
        }
    }
