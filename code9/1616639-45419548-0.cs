    string[] blocks = str.Split(new char[] {':', ' '}, StringSplitOptions.RemoveEmptyEntries);
    if (blocks[4].StartsWith("SORT_"))
    {
        Console.WriteLine(blocks[2]);
    }
