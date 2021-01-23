     var workspaceInfo = Workstation.Current.GetLocalWorkspaceInfo(modifiedPath);
    
        TfsTeamProjectCollection tpc = new TfsTeamProjectCollection(workspaceInfo.ServerUri);
        VersionControlServer vcServer = tpc.GetService<VersionControlServer>();
    
    
        using (var server = new TfsTeamProjectCollection(workspaceInfo.ServerUri))
        {
            var workspace = workspaceInfo.GetWorkspace(server);
    
            QueryHistoryParameters historyParams = new QueryHistoryParameters(modifiedPath, RecursionType.Full);
    
            historyParams.MaxResults = 1;
    
            Changeset changeset = vcServer.QueryHistory(historyParams).FirstOrDefault();
    
            string theUser = changeset.CommitterDisplayName;
    
            MessageBox.Show(theUser);
        }
