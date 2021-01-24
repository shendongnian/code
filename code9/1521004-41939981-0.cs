    public Book[] GetUnique(BookBundle[] bundles)
    {
        Dictionary<string, Book> dict = new Dictionary<string, Book>();
        foreach (BookBundle b in bundles)
        {
            Book bk;
            if(!dict.TryGetValue(b.Book1.ISBN, out bk))
                dict.Add(b.Book1.ISBN, b.Book1);
            if (!dict.TryGetValue(b.Book2.ISBN, out bk))
                dict.Add(b.Book2.ISBN, b.Book2);
    
        }
        return dict.Values.ToArray();
    }
