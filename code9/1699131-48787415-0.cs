    string[] tmp =
    {
        "Apple",
        "Apple",
        "Apple",
        "Pear",
        "Banana",
        "Banana"
    };
    string[] tmp2 =
    {
        "Pear",
        "Banana"
    };
    IEnumerable<string> uniqueList = tmp.Distinct(); // Removes doubles
    IEnumerable<string> notInTmp2 = tmp.Distinct().Except(tmp2); // could be also interesting ;)
    Console.WriteLine(string.Join(", ", uniqueList));
    Console.WriteLine(string.Join(", ", notInTmp2));
