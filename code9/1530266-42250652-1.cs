    static void Main()
    {
        List<GameVersion> GameVersionList = new List<GameVersion>();
        GameVersionList.Add(new GameVersion() { Name = "Game 3.1", Code = "1" });
        GameVersionList.Add(new GameVersion() { Name = "Game 3.2", Code = "10" });
        GameVersionList.Add(new GameVersion() { Name = "Game 3.3", Code = "11" });
        GameVersionList.Add(new GameVersion() { Name = "Game 3.2", Code = "9" });
        GameVersionList.Add(new GameVersion() { Name = "Game 3.18", Code = "7" });
        GameVersionList.Add(new GameVersion() { Name = "Game 3.27", Code = "12" });
        GameVersionList.Add(new GameVersion() { Name = "Game 3.11.2", Code = "13" });
        GameVersionList.Add(new GameVersion() { Name = "Game 3.2", Code = "2" });
        GameVersionList.Add(new GameVersion() { Name = "Game 3.8", Code = "5" });
        GameVersionList.Add(new GameVersion() { Name = "Game 3.10", Code = "7" });
        GameVersionList.SortNatural(item => item.Name);
        foreach (var item in GameVersionList)
        {
            Console.WriteLine(item.Name + ": " + item.Code);
        }
    }
