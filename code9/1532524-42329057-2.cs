    public void Search()
    {
        Console.Write("\tKeyword: ");
        string keyword = Console.ReadLine();
        List<string> moList = new List<string>();
        foreach ( var item in log )
        {
            model mo = new model();
            mo.localDate = log[0];
            mo.title = log[1];
            mo.desc = log[2];
        }
        List<string> searchResults = new List<string>();
        for (int a = 0; a < moList.Count; a++)
        {
            foreach (model item in moList[a])
            {
                if (item.title.Contains(keyword) || item.desc.Contains(keyword)){
                     searchResults.Add(item);
                }
            }
        }
        Console.WriteLine("Search Results: ");
        for (int b = 0; b < searchResults.Count; b++)
        {
             Console.WriteLine("\t{0}\t{1}\t\t{2}", searchResults[b][0], searchResults[b][1], searchResults[b][2]);
        }
    }
    
    
