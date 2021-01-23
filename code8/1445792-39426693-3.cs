    public class TokenResponse
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
        public string userName { get; set; }
        public string issued { get; set; }
        public string expires { get; set; }
    }
    private async Task Login()
    {
        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri("https://localhost:44305");
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("username", "alice@example.com"),
                new KeyValuePair<string, string>("password", "password1")
            });
            var result = await client.PostAsync("/token", content);
            string resultContent = await result.Content.ReadAsStringAsync();
            var tokenResponse = JsonConvert.DeserializeObject<TokenResponse>(resultContent);
        }
    }
