    if (string.IsNullOrWhiteSpace(d) && string.IsNullOrWhiteSpace(s))
        return;
    if(string.IsNullOrEmpty(d))
        Console.Write(s);
    if (string.IsNullOrEmpty(s))
        Console.Write(d);
}
