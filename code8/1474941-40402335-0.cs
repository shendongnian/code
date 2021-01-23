    public async Task MyTest() {
        using (HttpClient httpClient = new HttpClient()) {
            httpClient.BaseAddress = new Uri(_uri);
            var response = await httpClient.GetAsync("API/GetData");
            if(response!=null && response.IsSuccessStatusCode) {
                var json = await response.Content.ReadAsStringAsync();
            }
        }
    }
