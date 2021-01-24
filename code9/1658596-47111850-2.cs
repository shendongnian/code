    int totalCount = 0;
    var issuesByWeek = from issue in getDetails
                       where issue.ChangedTo == "Open" || issue.ChangedTo == "Closed"
                       group issue by issue.Date.EndOfWeek() into g
                       orderby g.Key
                       select new
                       {
                           Week = g.Key,
                           Count = totalCount += g.Sum(i => i.ChangedTo == "Open" ? 1 : -1)
                       };
