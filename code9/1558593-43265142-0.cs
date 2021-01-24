    using (DbEntities db = new DbEntities())
    {
        // The local book dictionary
        Dictionary<int, Book> books = new Dictionary<int, Book>();
    
        // Loop through big file to import each row
        foreach (var item in bigFile)
        {
            Person person = new Person { FirstName = item.FirstName, LastName = item.LastName };
    
            foreach (var itemBook in item.Books)
            {
                Book book;
    
                // Try get from local dictionary
                if (!books.TryGetValue(itemBook.BookId, out book))
                {
                    // Try get from db
                    book = db.Books.FirstOrDefault(e => e.BookId == itemBook.BookId);
                    if (book == null)
                    {
                        // Add book to DB if doesn't exist
                        book = new Book { BookId = itemBook.BookId, Name = itemBook.Name };
                        db.Books.Add(book);
                    }
                    // add to local dictionary
                    books.Add(book.BookId, book);
                }
    
                person.Books.Add(book);
            }
    
            db.People.Add(person);
        }
    
        db.SaveChanges();
    }
