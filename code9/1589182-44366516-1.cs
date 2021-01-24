    using (var client = new HttpClient())
    {
        using (var content = new FormUrlEncodedContent(values)) // this must be a dictionary or a IEnumerable<KeyValuePair<string, string>>
        {
            content.Headers.Clear();
            content.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            HttpResponseMessage response = await httpClient.PostAsync(url, content);
            var result = await response.Content.ReadAsAsync<MyResultClass>();
        }
    }
