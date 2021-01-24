        using (var db = new Db())
        using (var tran = db.Database.BeginTransaction())
        {
            db.Database.ExecuteSqlCommand("exec sp_getapplock 'MyAppLock','exclusive';");
            
            //only one thread across all application instances will execute this code at one time
            tran.Commit();
        }
