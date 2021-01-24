    private static void ServiceBorrower()
    {
        if (borrowers.Count == 0)
        {
            Console.WriteLine($"There are no more borrowers waiting in line.");
        }
        else if (books.Count == 0)
        {
            Console.WriteLine($"There are no more books to loan.");
            if (returners.Count > 0)
            {
                Console.WriteLine(" - Hint: There are people waiting to return books.");
            }
        }
        else
        {
            var borrower = borrowers.Dequeue();
            var book = books.Pop();
            borrower.BorrowedBook = book;
            Console.WriteLine($"{borrower.Name} borrowed {book.Title}");
            returners.Enqueue(borrower);
        }
    }
    private static void ServiceReturner()
    {
        if (returners.Count == 0)
        {
            Console.WriteLine($"There are no more returners waiting in line.");
        }
        else
        {
            var returner = returners.Dequeue();
            var book = returner.BorrowedBook;
            returner.BorrowedBook = null;
            Add(book);
            Console.WriteLine($"{returner.Name} has returned {book.Title}.");
            Console.Write("Do they want to borrow another one (Y/N)?: ");
            var input = Console.ReadKey();
            Console.WriteLine();
            if (input.Key == ConsoleKey.Y)
            {
                Lineup(returner);
            }                
        }
    }
