    // Letter List
    public static List<char> letter = Enumerable.Range(1, 50)
                                            .Select(i => '\0') // null char
                                            .ToList();
    // Index Number List
    public static List<string> indexLetter = Enumerable.Range(1, 50)
                                            .Select(i => i.ToString()) // number
                                            .ToList();
