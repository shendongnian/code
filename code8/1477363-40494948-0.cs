    using (HttpClient httpClient = new HttpClient())
    {
        httpClient.BaseAddress = new Uri(@"http://test.com/");
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        httpClient.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("utf-8"));
        string endpoint = @"/api/testendpoint";
        try
        {
            HttpContent content = new StringContent(JsonConvert.SerializeObject(log), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PostAsync(endpoint, content);
            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                //do something with json response here
            }
        }
        catch (Exception)
        {
            //Could not connect to server
            //Use more specific exception handling, this is just an example
        }
    }
