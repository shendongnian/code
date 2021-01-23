    string[] lines = File.ReadAllLines(@"g:\\myfile.DAT");
    var result = lines.AsParallel()
                      .OrderBy(s => Convert.ToDouble(s.Split('>').Last()))
                      .ToList();
    result.ForEach(Console.WriteLine);
