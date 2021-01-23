    calculate(Enumerable.Range(0, array2Db.GetLength(1)).Select(y => array2Db[2, y]));
    static void calculate(IEnumerable<string> words)
    {
        foreach(string word in words)
            Console.WriteLine(word);
    }
