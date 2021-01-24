    string line;
    while (!string.IsNullOrEmpty(line = listReader.ReadLine()))
    {
        w.WriteLine(listReader.ReadLine());
    }
