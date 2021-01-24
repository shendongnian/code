    public async Task<Book> getBook(int id)
    {
        string urlAction = String.Format("api/book/{0}", id);
        return await GetWSObject<Book>(urlAction);
    }
    
    public async Task<string> getBooksByAuthor (int authorId) 
    {
        string result = "";
    
        var books = from a in db.Authors
                    where a.id == authorId
                    select new
                    {
                        id = a.id
                    };
    
        foreach (var book in books.ToList())
        {
            var bookdata = await this.getBook(book.id);
            result += bookdata.name + ", ";   
        }
    
        return result; 
    }
