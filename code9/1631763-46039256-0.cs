    foreach (dynamic rec in new ChoCSVReader("quotes.csv").WithDelimiter(";"))
    {
        Console.WriteLine("{0}", rec[11]);
        Console.WriteLine("{0}", rec[12]);
        Console.WriteLine("{0}", rec[13]);
        Console.WriteLine("{0}", rec[14]);
        Console.WriteLine("{0}", rec[15]);
    }
