    System.IO.File.Delete(@"H:\Compare.txt");
    foreach (var value in lstStore103.Intersect(lstStore101))
    {
        checkResults.Add(value);
        System.IO.File.AppendAllText(@"H:\Compare.txt", value + Environment.NewLine);
    }
