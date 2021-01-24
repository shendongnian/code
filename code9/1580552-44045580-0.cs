    public static void tryOut()
    {
        #region file.read
        var cells = new List<string>();
        try
        {
            var fileLocation = @"C:\Users\Lucas\Desktop\Tok.txt";
            cells = File.ReadAllLines(fileLocation).ToList();
        }
        catch
        {
            throw new FileNotFoundException();
        }
        aray(cells);
        #endregion
    }
