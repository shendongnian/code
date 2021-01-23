    using(var client = new HttpClient())
    {
        for (int i = 0; i < 100; i++)
        {
            HttpResponseMessage response = client.GetAsync("http://localhost").Result;
            string responseString = response.Content.ReadAsStringAsync().Result;
        }
    }
