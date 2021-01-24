     IVsDataExplorerConnectionManager decMgr = (IVsDataExplorerConnectionManager)this.ServiceProvider.GetService(typeof(IVsDataExplorerConnectionManager));
    
     foreach (var conn in decMgr.Connections)
     {
          var state = conn.Value.Connection.State;
          if (state == DataConnectionState.Closed)
          {
              conn.Value.Connection.Open();
          }
     }
