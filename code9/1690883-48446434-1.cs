    int totalBooks = 25;
    Books[] myBooks = new Books[totalBooks]; // 25 is the number of books an the indexes are from 0 to 24
    for (int i = 0; i < totalBooks; i++)
    {
        Books newbook = new Books();
        Console.WriteLine("\nPlease input the name, description and price of the book {0} :\n", (i+1));
        newbook.name = Console.ReadLine();
        newbook.description = Console.ReadLine();
        newbook.price = Convert.ToDouble(Console.ReadLine());
        myBooks[i] = newbook;
        //Displaying what the user just entered
        Console.WriteLine("{0} - {1}: {2}. Price: {3}", (i+1), newbook.name, newbook.description, newbook.price);
    }
