    public ThisViewModel()
    {
        Book = new ObservableCollection<Book>();
        ExistedBooks = new List<Book>();
        Book bookA = new Book() { Title = "Title A" };
        Book.Add(bookA);
        ExistedBooks.Add(bookA);
    }
