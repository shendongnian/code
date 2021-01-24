        using (Database db = new Database(CONNECTIONSTRING, DatabaseType.SQLCe))
        {
            System.Diagnostics.Debug.Print(DateTime.Now.ToString());
            db.BeginTransaction();     // <------
            db.InsertBulk(many);
            db.CompleteTransaction();  // <------
            System.Diagnostics.Debug.Print(DateTime.Now.ToString());
        }
