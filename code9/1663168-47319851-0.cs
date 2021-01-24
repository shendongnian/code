    // Fix #1
    public void print_book(int x, ListBox f)
    {
        //List<Book> BookList = new List<Book>(); // Comment this line
        foreach (var k in BookList)
        {
            if (x == k._id2)
            {
                f.Items.Add(x);
            }
        }
    }
    // Fix #2
    public void print_book(int x, ListBox f)
    {
        List<Book> BookList = new List<Book>(); // 'BookList' has never been used
        foreach (var k in this.BookList) // Add 'this'
        {
            if (x == k._id2)
            {
                f.Items.Add(x);
            }
        }
    }
