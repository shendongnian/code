    using (var tran = ctx.Database.BeginTransaction())
    {
        try
        {
            const string lockName = "MYLOCKNAME";
            var resourceParam = new SqlParameter("Resource", SqlDbType.NVarChar, 255) { Value = lockName };
            var lockModeParam = new SqlParameter("LockMode", SqlDbType.NVarChar, 32) { Value = "Transaction" };
            ctx.Database.ExecuteSqlCommand("EXEC sp_getapplock @Resource, @LockMode", resourceParam, lockModeParam);
            // Do stuff with ctx
            // ...
            tran.Commit();
        }
        catch
        {
            tran.Rollback();
        }
    }
