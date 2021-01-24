    var f1Lines = File.ReadAllLines(@"D:\test1.txt").ToList();
    var f2Lines = File.ReadLines(@"D:\test2.txt").ToList();
    var result = new List<string>();
    foreach (var item in f1Lines)
    {
        var found = f2Lines.Where((line) => line.Contains(item)).FirstOrDefault();
        if (found != null)
        {
            result.Add(found);
        }
    }
    File.WriteAllLines(@"D:\result.txt", result);
