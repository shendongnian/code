    string input = Console.ReadLine();
    int? tec = null;
    if (!string.IsNullOrEmpty(input))
    {
        tec = int.Parse(input);
    }
    int avetec = tec ?? 0;
