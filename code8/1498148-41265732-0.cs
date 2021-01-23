    using (SqlConnection conn = new SqlConnection(connString)) {
        XEStore store = new XEStore(new SqlStoreConnection(conn));
        if (store.Sessions[sessionName] != null) {
            Console.WriteLine("dropping existing session");
            store.Sessions[sessionName].Drop();
        }
        Session s = store.CreateSession(sessionName);
        s.MaxMemory = 4096;
        s.MaxDispatchLatency = 30;
        s.EventRetentionMode = Session.EventRetentionModeEnum.AllowMultipleEventLoss;
        Event rpc = s.AddEvent("rpc_completed");
        rpc.AddAction("username");
        rpc.AddAction("database_name");
        rpc.AddAction("sql_text");
        rpc.PredicateExpression = @"sqlserver.username NOT LIKE '%testuser'";
        s.Create();
        s.Start();
        //s.Stop();
        //s.Drop();
    }
