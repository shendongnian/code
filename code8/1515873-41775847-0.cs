        const string selectIsolationLevel = @"SELECT CASE transaction_isolation_level  WHEN 0 THEN 'Unspecified'  WHEN 1 THEN 'ReadUncommitted'  WHEN 2 THEN 'ReadCommitted'  WHEN 3 THEN 'Repeatable'  WHEN 4 THEN 'Serializable'  WHEN 5 THEN 'Snapshot' END AS TRANSACTION_ISOLATION_LEVEL  FROM sys.dm_exec_sessions  where session_id = @@SPID";
        static void ReadUncommitted()
        {
            using (var scope =
                new TransactionScope(TransactionScopeOption.RequiresNew,
                new TransactionOptions{ IsolationLevel = IsolationLevel.ReadUncommitted }))
            using (myEntities db = new myEntities())
            {
                Console.WriteLine("Read is about to be performed with isolation level {0}", 
                    db.Database.SqlQuery(typeof(string), selectIsolationLevel).Cast<string>().First()
                    );
                var data = from _Contact in db.Contact where _Contact.MemberId == 13 select _Contact; // large results but with nolock
                foreach (var item in data)
                    item.Flag = 0;
                //Using Nuget package https://www.nuget.org/packages/Serilog.Sinks.Literate
                //logger = new Serilog.LoggerConfiguration().WriteTo.LiterateConsole().CreateLogger();
                //logger.Information("{@scope}", scope);
                //logger.Information("{@scopeCurrentTransaction}", Transaction.Current);
                //logger.Information("{@dbCurrentTransaction}", db.Database.CurrentTransaction);
                //db.Database.ExecuteSqlCommand("-- about to save");
                db.SaveChanges(); // Try avoid db lock
                //db.Database.ExecuteSqlCommand("-- finished save");
                //scope.Complete();
            }
        }
