    var existingIssue = newContext.Issues.Where(i => i.IssueId == issueId).FirstOrDefault();
    
    existingIssue.IssueTypeId = issueTypeId;
    
    newContext.SaveChanges();
