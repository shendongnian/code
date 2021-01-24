    if (!parser.EndOfData) {
        parser.ReadLine();
    }
    while (!parser.EndOfData)
    {
        var fields = parser.ReadFields();
        ...
    }
