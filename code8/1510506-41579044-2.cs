    var childIssues = (from i in Issues
                 where LinkedIssues.Any(li => (li.IssueId == 28438 && li.ChildIssueId == i.IssueId) 
				                        || (li.ChildIssueId == 28438 && li.IssueId == i.IssueId)
                 select new LinkedIssuesModel()
                 {
                     IssueID = li.ChildIssueId,
                     CustomerName = i.Room.Location.Customer.CustomerName,
                     LocationName = i.Room.Location.LocationName,
                     ReceivedDate = i.ReceivedDate,
                     IssueSummary = i.IssueSummary,
                     IssueDescription = i.IssueDescription
                 }).ToList();
