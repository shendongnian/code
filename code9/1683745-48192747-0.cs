        // Get the submodules 
        foreach (Submodule subrepo in mainRepo.Submodules)
        {
          getSubModule(mainRepo, tempRootWorkDir, subrepo.Path, subrepo.IndexCommitId.ToString());
        }
    
        /// <summary>
        /// Check out a submodule to work directory
        /// </summary>
        private static void getSubModule(Repository repo, string workdir, string entryPath, string entryId )
        {
          // Checkout to the temp directory, set index options
          string subtempIndex_at = Path.Combine(workdir, "index__" + GitInteractor.GetRandomId());
          var sub_opts_at = new RepositoryOptions
          {
            WorkingDirectoryPath = Path.Combine(workdir, entryPath),
            IndexPath = subtempIndex_at
          };
    
          // Sub repository path in the main repo
          string subdir = Path.Combine(repo.Info.WorkingDirectory, entryPath);
          using (Repository subRepo = new Repository(subdir, sub_opts_at))
          {
            // Get the sub repo commit at the entry id, this way the repos will be 
            // in sync through time ( between main repo and sub repo )
            Commit commit = subRepo.Lookup<Commit>(entryId);
            // Hard / exact
            subRepo.Reset(ResetMode.Hard, commit);
          }
        }
