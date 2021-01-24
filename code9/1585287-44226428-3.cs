    public async Task<ModelPageLocationList> RefreshPageLocationListAsync () {
        try {
            var uri = new Uri(string.Format(WebServiceSettings.WebServiceUrl, string.Empty));
            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode) {
                var result = await response.Content.ReadAsAsync<ModelPageLocationList>();
                return result;
            }
        } catch (Exception ex) {
            Debug.WriteLine(@"ERROR {0}", ex.Message);
        }
        return null; 
    } 
