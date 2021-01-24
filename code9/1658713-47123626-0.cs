    private static async Task<Topics> GetTopics(string repoFullName)
    {
        var client = new HttpClient();
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/vnd.github.mercy-preview+json"));
        client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue(
                "Basic",
                Convert.ToBase64String(
                    Encoding.ASCII.GetBytes(
                        string.Format("{0}:{1}", "username", "password"))));
        client.DefaultRequestHeaders.Add("User-Agent", "my-cool-app");
        var stringTask = client.GetStringAsync(
            $"https://api.github.com/repos/{repoFullName}/topics");
        var response = await stringTask;
        var topics = JsonConvert.DeserializeObject<Topics>(response);
        return topics;
    }
