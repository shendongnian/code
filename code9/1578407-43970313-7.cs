    private static void Lineup()
    {
        var newReader = new Reader();
        Console.Write("Enter the name of the new reader: ");
        newReader.Name = Console.ReadLine();
        // Now that we have a reader object, call the 
        // other version of this method to add it
        Lineup(newReader);
    }
    private static void Lineup(Reader borrower)
    {
        borrowers.Enqueue(borrower);
        Console.WriteLine($"{borrower.Name} lined up to borrow a book.");
    }
    private static void Add()
    {
        var newBook = new Book();
        Console.Write("Enter the book title: ");
        newBook.Title = Console.ReadLine();
        Console.Write("Enter the book author: ");
        newBook.Author = Console.ReadLine();
        Console.Write("Enter the book ISBN: ");
        newBook.ISBN = Console.ReadLine();
        // Now that we have a book object, call the 
        // other version of this method to add it
        Add(newBook);
    }
    private static void Add(Book book)
    {
        books.Push(book);
        Console.WriteLine($"Added '{book.Title}' to the library.");
    }
