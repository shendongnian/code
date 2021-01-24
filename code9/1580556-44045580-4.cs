    public void tryOut()
    {
        #region file.read
        var fileLocation = @"Path";
        aray(File.ReadAllLines(fileLocation).ToList());
        #endregion
    }
    public static void aray(List<string> cells)
    {
        List<string> t = new List<string>();
        foreach (string cell in cells)
        {
            string[] eachCell = cell.Split('@', '\t');
            foreach (var e in eachCell)
            {
                t.Add(e);
            }
        }
        foreach (var e in t)
        {
            Console.WriteLine(e);
        }
    }
