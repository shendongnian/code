    var wiIds = (await git
        .GetCommitsAsync(
            project,
            repository,
            new GitQueryCommitsCriteria
            {
                // ItemVersion query seems to disregard the Top parameter and returns 100 commits instead at least in TFS 2018.2
                // So we use From+To query
                FromCommitId = commitId,
                ToCommitId = commitId,
                IncludeWorkItems = true,
                Top = 1
            }))
        .Single()
        .WorkItems()
        .Select(wiRef => 
            Int32.Parse(wiRef.Id))
