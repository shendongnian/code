    DbTransaction trans = dbConn.BeginTransaction();
    try
    {
        // ... do your stuff...
        // Last line of the try-block... if you are still alive here, commit
        trans.Commit();
    }
    catch (Exception e)
    {
         // Something evil happened... Rollback
         trans.Rollback();
    }
