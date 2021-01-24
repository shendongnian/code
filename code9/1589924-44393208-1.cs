    public async Task<string> GET(string uri) {
        try {
            Client.BaseAddress = new Uri(BASE_URI);
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var fullUri = String.Format("api/{0}/{1}", Controller, uri);
            var response = await Client.GetAsync(fullUri);
            var content = await response.Content.ReadAsStringAsync();
            return content;
        } catch (Exception e) {
            return null;
        }
    }
