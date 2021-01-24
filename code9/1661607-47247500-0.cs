    var array = new List<string>();
    
    using (var sr = new StreamReader("four_letter.txt"))
    {
        while (!sr.EndOfStream)
        {
            var line = sr.ReadLine();
            array.AddRange(line.Split('\t'));
        }
    }
