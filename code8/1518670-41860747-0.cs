    private const string FilePath = "../../TextFiles/txtPlayer.txt";
    private static void LoadUsers()
    {
        _users = new Dictionary<string, string>();
        using (var sr = new StreamReader(FilePath))
        {
            string line = sr.ReadLine();
            string[] lineArray = line?.Split(',');
            if (lineArray?[0] != null && lineArray[1] != null)
                _users.Add(lineArray[0].ToString(), lineArray[1].ToString());
        }
    }
