            // Union left outer join and right outer join to perform full outer join
            // https://stackoverflow.com/a/5491381/5682608
            var leftOuterJoin = from newIssue in newIssues
                                join closedIssue in closedIssues
                                on newIssue.Week equals closedIssue.Week
                                into temp
                                from closedIssue in temp.DefaultIfEmpty(new IssueCount { Week = newIssue.Week, Count = 0 })
                                select new IssueCount
                                {
                                    Week = newIssue.Week,
                                    Count = newIssue.Count - closedIssue.Count
                                };
            var rightOuterJoin = closedIssues.Where(issue => !newIssues.Select(newIssue => newIssue.Week).Contains(issue.Week));
            
            // Modified: Following code can generate duplicated entries when
            // 2 IssueCounts of the same Week have different values in Count property
            // 
            //var rightOuterJoin = from closedIssue in closedIssues
            //                     join newIssue in newIssues
            //                     on closedIssue.Week equals newIssue.Week
            //                     into temp
            //                     from newIssue in temp.DefaultIfEmpty(new IssueCount { Week = closedIssue.Week, Count = 0 })
            //                     select new IssueCount
            //                     {
            //                         Week = closedIssue.Week,
            //                         Count = closedIssue.Count - newIssue.Count
            //                     };
            var fullOuterJoin = leftOuterJoin.Union(rightOuterJoin);
            foreach (var issue in fullOuterJoin.OrderBy(i => i.Week))
            {
                Console.WriteLine($"{issue.Week.ToString("MM/dd/yyyy")} : {issue.Count}");
            }
