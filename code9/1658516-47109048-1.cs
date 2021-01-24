    var totalIssuesList = openIssuesList;
    foreach (var closedWeekCount in closedIssuesList)
    {
        var totalWeekCount = totalIssuesList.FirstOrDefault(owc => owc.Week == closedWeekCount.Week);
        if (totalWeekCount != null)
        {
            totalWeekCount.Count = totalWeekCount.Count - closedWeekCount.Count;
        }
        else
        {
            totalIssuesList.Add(closedWeekCount);
        }
    }
    totalIssuesList = totalIssuesList.OrderBy(twc => twc.Week).ToList();
