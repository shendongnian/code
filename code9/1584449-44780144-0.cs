        #addin "Cake.Git"
        using LibGit2Sharp;
        
        var solutionFolder = "./";
        var versionTag = "someTag";
        var remoteRepository = EnvironmentVariable("bamboo_planRepository_repositoryUrl");
        var repositoryRevision = EnvironmentVariable("bamboo_planRepository_revision");
        
        Task("Default")
            .Does(() =>
            {
                var absolutePath = MakeAbsolute(Directory(solutionFolder));
                var repoName = "central";
        
                //LibGit2Sharp add remote  
                using (var repo = new Repository(absolutePath.FullPath))
                {
                    repo.Network.Remotes.Add(repoName, remoteRepository);
                }
        
                GitTag(solutionFolder, versionTag, repositoryRevision);
        	    Cmd($"git push {repoName} {versionTag}");
            }
        });
          
    private void Cmd(params object[] parameters)
    {
    	if (parameters.Any())
    	{
    		var args =  new ProcessArgumentBuilder()
                .Append(@"/c");
    		 
    		foreach (var param in parameters)
    			args.Append($"{param}");
    
    		StartProcess("cmd", new ProcessSettings { Arguments = args });
    	}
    }
  
