    public IEnumerable<Book> GetBooks()
    {
          client.DefaultRequestHeaders.Add("Authorization", "Bearer " + MyToken.myToken);
    
          HttpResponseMessage responseMessage = client.GetAsync(url).Result;
    
          if (responseMessage.IsSuccessStatusCode)
          {
             var responseData = responseMessage.Content.ReadAsStringAsync().Result;
    
             var books = JsonConvert.DeserializeObject<IEnumerable<Book>>(responseData);
    
             return books;
          }    
    
          return new List<Book> {};        
