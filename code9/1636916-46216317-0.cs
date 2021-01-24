    System.IO.File.Delete(@"H:\Compare.txt");
    foreach (var single103 in lstStore103)
    {
        foreach (var single101 in lstStore101)
        {
            if (single101 == single103)
            {
                checkResults.Add(single103);
                System.IO.File.AppendAllText(@"H:\Compare.txt", single103 + Environment.NewLine);
                break;
            }
        }
    }
