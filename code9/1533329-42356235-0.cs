        using(var client = new HttpClient())
        {
            client.BaseAddress = "http://baseApiAddress.com";
            var values = new Dictionary<string, string>
            {
                { "clientId", "cloudidx" },
                { "password", "65912" }
            };
            var content = new FormUrlEncodedContent(values);
            var response = await client.PostAsync("apiMethod", content);
            string responseString = String.Empty;
            if(response.IsSuccessStatusCode)
            {
                responseString = await response.Content.ReadAsStringAsync();
            }
        }
        return View();
