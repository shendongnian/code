    string input = "2000-02-02";
    DateTime dateTime;
    if (DateTime.TryParse(input, out dateTime))
    {
        Console.WriteLine(dateTime);
    }
