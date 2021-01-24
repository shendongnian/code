            using (var repo = new Repository(@"repoPath"))
            {
                Tag tagTo  = repo.Tags["tag2"];
                Tag tagFrom  = repo.Tags["tag1"];
                var commitFrom = repo.Lookup<LibGit2Sharp.Commit>(tagFrom.Target.Sha);
                var commitTo = repo.Lookup<LibGit2Sharp.Commit>(tagTo.Target.Sha);
                TreeChanges treeChanges = repo.Diff.Compare<TreeChanges>(commitFrom.Tree, commitTo.Tree);
            }
