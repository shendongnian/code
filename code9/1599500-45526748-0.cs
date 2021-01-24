    var submoduleRepoId = (await gitHubClient.Repository.Get(submoduleRepoOwnerName, submoduleRepoName)).Id;
    var submoduleRepoBranchLatestSha = (await gitHubClient.Git.Tree.Get(submoduleRepoId, submoduleRepoBranchName)).Sha;
    …
    var updateParentTree = new NewTree { BaseTree = parentRepoBranchLatestSha };
    updateParentTree.Tree.Add(new NewTreeItem
    {
        Mode = FileMode.Submodule,
        Sha = submoduleRepoBranchLatestSha,
        Path = pathToSubmoduleInParentRepo,
        Type = TreeType.Commit,
    });
    var newParentTree = await gitHubClient.Git.Tree.Create(pullRequestOwnerForkRepoId, updateParentTree);
    var commitMessage = $"Bump to {submoduleOwnerName}/{submoduleRepoName}@{submoduleCommitHash}";
    var newCommit = new NewCommit(commitMessage, newParentTree.Sha, parentBranchLatestSha);
    var pullRequestBranchRef = $"heads/{pullRequestBranchName}";
    var commit = await gitHubClient.Git.Commit.Create(pullRequestOwnerName, parentRepoName, newCommit);
    var await gitHubClient.Git.Reference.Update(pullRequestOwnerForkRepoId, pullRequestBranchRef, new ReferenceUpdate(commit.Sha));
