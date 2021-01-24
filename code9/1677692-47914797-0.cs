    var pool = factory.ObjectPools.CreatePoolByServer("Pool1", server, login);
    var lease = pool.GetPooledObject(null, null, 5000);
    var workspace = (IWorkspace)lease.SASObject;
    var status = (IServerStatus)lease.SASObject;
    
    keeper.AddObject(1, workspace.UniqueIdentifier, workspace);
    
    using (var conn = new OleDbConnection("Provider=SAS.IOMProvider.1; Data Source=iom-id://" + status.ServerStatusUniqueID))
    {
        // success
        conn.Open();
    }
    
    keeper.RemoveObject(workspace);
    lease.ReturnToPool();
