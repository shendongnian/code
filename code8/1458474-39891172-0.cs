    string[] pieces = Regex.Split(theInputText, "(%3A.*?\\+(?:AND|OR))");
    foreach (string ss in pieces)
    {
        Console.WriteLine(ss);
    }
