    public static void mppF()
    {
        var orderedByCount = passwords
            .GroupBy(str => str)    // group by password
            .Select(g => new { Key = g.Key, Count = g.Count()) // select key and count
            .OrderBy(pair => pair.Count)  // sort
            .Select(pair => string.Format("{0:-45} | {1}", pair.Key, pair.Count); // construct output string
        File.WriteAllLines("mpp.dat", passwords);
        Console.WriteLine("DUN-DUN-DUUNNN!!!! (2)");
    }
