    var newList = openIssueList.Tolist();
    for (int i = 0; i < openIssuesList.Count - 1); i++)
    {
        //add mising dates
        var nextModay= openIssuesList(i).Week.AddDays(7);
        while (nextModay < openIssuesList(i+1).Week)
        {
            newList.Add(new {Week = nextModay, Count = openIssuesList(i).Count);
            nextModay= openIssuesList(i).Week.AddDays(7);
        }
    }
