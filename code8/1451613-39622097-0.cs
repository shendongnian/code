    var repo = new LibGit2Sharp.Repository("/Users/sushi/code/sushi/Xamarin.PlayScript.Starling");
    var filter = new CommitFilter()
    {
    	SortBy = CommitSortStrategies.Reverse 
    };
    IEnumerable<Commit> commits = repo.Commits.QueryBy(filter);
    foreach (var commit in commits)
    {
    	Console.WriteLine(commit.Committer.When);
    }
