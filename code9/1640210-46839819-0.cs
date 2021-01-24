                using (Repository repo = new Repository(repositoryPath))
                {
                    foreach (Submodule submodule in repo.Submodules)
					{
                        String subrepoPath = Path.Combine(repo.Info.WorkingDirectory, submodule.Path);
						using (Repository subRepo = new Repository(subrepoPath))
						{
							Branch remoteBranch = subRepo.Branches["origin/master"];
							subRepo.Reset(ResetMode.Hard, remoteBranch.Tip);
						}
					}
                }
