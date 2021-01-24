    context.Database.ExecuteSqlCommand(
        TransactionalBehavior.DoNotEnsureTransaction,
        "DBCC SHRINKDATABASE(@file)",
         new SqlParameter("@file", DatabaseTools.Instance.DatabasePathName)
    );
    
