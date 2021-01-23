    var text = Console.ReadLine();
    while(!String.IsNullOrEmpty(text))
    {
        TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
        Console.WriteLine(ti.ToTitleCase(text).Replace(" ", string.Empty));
        text = Console.ReadLine();
    }
