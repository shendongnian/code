    var list = oSIM.Issues.GroupJoin(db.IssueTracker_Read,
     c => c.IssueId,
     o => o.issueid,
     (c, o) => new
     {
        Issue = c,
        IssueRead = o.DefaultIfEmpty()
     }).Select(groupJoinInfo=> new { 
           groupJoinInfo.Issue,
           Read = groupJoinInfo.IssueRead != null && groupJoinInfo.IssueRead.Any()
         });
