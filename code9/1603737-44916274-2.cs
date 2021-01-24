    HttpClient client = new HttpClient();
    public async Task<NewsModel> GetNews(string query, string count) {
        NewsModel list = new NewsModel();
        var uri = "Some URL";
        using (var response = await client.GetAsync(uri)) {
            var responseData = await response.Content.ReadAsStringAsync();
            list = JsonConvert.DeserializeObject<NewsModel>(responseData);
            list.value.RemoveAll(item => item.image == null);
        }
        return list;
    }
