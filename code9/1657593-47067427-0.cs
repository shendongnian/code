    public void AddBook()
    {
        // You are creating new instance of BookModel here which is not bound to UI. 
        BookModel bk = new BookModel();
        SampleSQL exsql = new SampleSQL();
        exsql.NewBooks(bk.BookTitle, bk.BookAuthor);
    }
