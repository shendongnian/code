    string line = reader.ReadLine();
    while (!string.IsNullOrEmpty(line))
    {
        w.WriteLine(listReader.ReadLine());
        line = reader.ReadLine();
    }
