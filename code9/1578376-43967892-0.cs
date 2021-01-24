    var txtFile = File.ReadAllLines("test.txt");
    var meta = new List<string>();
    foreach (var line in txtFile)
    {
        var values = line.Split(new[] { '¬' });
        meta.Add(string.Join(",", values.Select(v => "\"" + v + "\"")));
    }
    File.WriteAllLines("meta.csv", meta);
