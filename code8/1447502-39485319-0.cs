    List<List<string>> PersonInfo = new List<List<string>>(){
    new List<string>() {"John", "Peter", "Watson"},
    new List<string>() {"1000", "1001", "1002"}};
    
    List<List<string>> PivitedPersonInfo = new List<List<string>>();
    for (int i = 0; i < PersonInfo.First().Count; i++)
    {
        PivitedPersonInfo.Add(PersonInfo.Select(x => x.ElementAt(i)).ToList());
    }
