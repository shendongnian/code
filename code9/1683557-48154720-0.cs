    public async Task<string> PostObjectToWebServiceAsJSON(object objectToPost, string validatorName, string method)
    {
        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri("myuri" + "/" + method);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.PostAsJsonAsync("", objectToPost).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            }
            else
            {
                return null;
            }
        }
    }
