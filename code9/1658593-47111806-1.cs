    var totalIssuesList = openIssuesList.Select(o => new WeekCount { Week = o.Week, Count = o.Count, IsOpen = true }).ToList();
    foreach (var closedWeekCount in closedIssuesList)
    {
        var totalWeekCount = totalIssuesList.FirstOrDefault(owc => owc.Week == closedWeekCount.Week);
        if (totalWeekCount != null)
        {
            totalWeekCount.Count = totalWeekCount.Count - closedWeekCount.Count;
        }
        else
        {
            totalIssuesList.Add(new WeekCount { Week = closedWeekCount.Week, Count = closedWeekCount.Count, IsOpen = false });
        }
    }
    totalIssuesList = totalIssuesList.OrderBy(twc => twc.Week).ToList();
    var currentCount = 0;
    foreach (var totalWeekCount in totalIssuesList)
    {
        if (totalWeekCount.IsOpen)
        {
            currentCount += totalWeekCount.Count;
        }
        else
        {
            currentCount -= totalWeekCount.Count;
        }
        totalWeekCount.Count = currentCount;
    }
