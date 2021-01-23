    var childIssues = Issues.
                        Where(x => LinkedIssues.
                                     Where(z => z.IssueId = 28438).
                                     Select(z => z.ChildIssueId).
                                     Contains(x.IssueID) 
                                 ||
                                   LinkedIssues.
                                     Where(z => z.ChildIssueId = 28438).
                                     Select(z => z.IssueId).
                                     Contains(x.IssueID) 
                        );
