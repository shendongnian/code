    public void tryOut()
    {
        #region file.read
        var fileLocation = @"Path";
        aray(File.ReadAllLines(fileLocation).ToList());
        #endregion
    }
    public void aray(List<string> cells)
    {
        List<string> t = new List<string>();
        foreach (string cell in cells)
        {
            string[] eachCell = cell.Split('@', '\t');
            t.Add(eachCell[0]);
            t.Add(eachCell[1]);
            t.Add(eachCell[2]);
            t.Add(eachCell[3]);
        }
        foreach (var e in t)
        {
            Console.WriteLine(e);
        }
    }
