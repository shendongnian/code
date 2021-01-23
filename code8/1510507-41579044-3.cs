	    var childIssues = (from i in Issues
	                 from li in LinkedIssues
	                 where (li.IssueId == 28438 && li.ChildIssueId == i.IssueID) 
                        || (li.ChildIssueId == 28438 && li.IssueId == i.IssueID)
	                 select new LinkedIssuesModel()
	                 {
	                     IssueID = li.ChildIssueId,
	                     CustomerName = i.Room.Location.Customer.CustomerName,
	                     LocationName = i.Room.Location.LocationName,
	                     ReceivedDate = i.ReceivedDate,
	                     IssueSummary = i.IssueSummary,
	                     IssueDescription = i.IssueDescription
	                 }).ToList();
