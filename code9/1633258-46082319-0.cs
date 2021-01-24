    using (MyDataBase db = new DataBase())
    {
        using (var dbContextTransaction = db.Database.BeginTransaction())
        {
            try
            {
                //Inserting several records to different tables
                var newEntity = new Entity();
                ...
                db.Entity.Add(newEntity);
    
                db.SaveChanges();
                db.up_StoredProcCall;
                dbContextTransaction.Commit();
            }
            catch (Exception ex)
            {
                dbContextTransaction.Rollback();
                db.Dispose();
    
                using (MyDataBase dbLog = new DataBase())
                {
                  var logEntry = new LogEntry();
                  ...
                  dbLog.LogEntry.Add(logEntry);
                  dbLog.SaveChanges();
    
                }
    
            }
        }
    }
