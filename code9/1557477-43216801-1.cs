    public async Task<IEnumerable<Book>> GetBooks()
    {
        IEnumerable<Book> books = new List<Book>();
        using (HttpClient client = new HttpClient())
        {
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + MyToken.myToken);
            HttpResponseMessage responseMessage = await client.GetAsync(url);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = await responseMessage.Content.ReadAsStringAsync();
                books = JsonConvert.DeserializeObject<IEnumerable<Book>>(responseData);
            }
        }
        return books;
    }
