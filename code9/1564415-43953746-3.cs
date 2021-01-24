            using (var repo = new Repository(@"repoPath"))
            {
                Tag tagTo  = repo.Tags["tag2"];
                Tag tagFrom  = repo.Tags["tag1"];
                var filter = new CommitFilter();
                filter.IncludeReachableFrom = tagTo.Target.Sha;
                filter.ExcludeReachableFrom = tagFrom.Target.Sha;
                var commits = repo.Commits.QueryBy(filter).ToList();
            }
