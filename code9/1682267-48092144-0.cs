    using (var conn = new SqlConnection("...")) 
    { 
        conn.Open(); 
        using (var sqlTxn = conn.BeginTransaction(System.Data.IsolationLevel.Snapshot)) 
        { 
            using (var context =  new MyDBEntities(conn, contextOwnsConnection: false)) 
            { 
                context.Database.UseTransaction(sqlTxn);
                // ...
            }
            
        }
    }
