    public void AddBook(Book book)
    {
        using (var ctx = new DatabaseContext())
        {
            ctx.Books.Add(book);
            if (boot.Customer == null)
                book.Customer = new Customer();
            ctx.SaveChanges();
        }
    }
