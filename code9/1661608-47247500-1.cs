    var array = new List<string>();
    
    using (var sr = new StreamReader("file.txt"))
    {
        string line;
        while ((line = sr.ReadLine()) != null)
        {
            array.AddRange(line.Split('\t'));
        }
    }
