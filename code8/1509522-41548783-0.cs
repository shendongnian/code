    private async Task GetUserTask(HttpClient client, StringContent content)
    {
        using (client)
        {
            HttpResponseMessage res = await client.PostAsync(url, content).ConfigureAwait(false);
            res.EnsureSuccessStatusCode();
            if (res.IsSuccessStatusCode)
            {
                var response = await res.Content.ReadAsStringAsync().ConfigureAwait(false);
            }
        }
    }
