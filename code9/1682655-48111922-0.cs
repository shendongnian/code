    public IEnumerable<TfvcChangesetRef> ListChangesets() 
    { 
        VssConnection connection = this.Context.Connection; 
        TfvcHttpClient tfvcClient = connection.GetClient<TfvcHttpClient>(); 
         
        IEnumerable<TfvcChangesetRef> changesets = tfvcClient.GetChangesetsAsync(top: 10).Result; 
        
        foreach (TfvcChangesetRef changeset in changesets) 
        { 
            Console.WriteLine("{0} by {1}: {2}", changeset.ChangesetId, changeset.Author.DisplayName, changeset.Comment ?? "<no comment>"); 
        } 
        
        return changesets; 
    } 
