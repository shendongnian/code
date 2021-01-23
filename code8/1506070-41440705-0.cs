    private void Process<T>(Func<DatabaseContext , DbSet<T>> selector)
        where T : DataRecord
    {
        using( var context = new DatabaseContext() )
        {
            var dataRecords = selector(context);
            context.Configuration.AutoDetectChangesEnabled = false;
    
            var data = dataRecords
                .Where( ... )
                .ToList();
    
            // operate and transform data 
    
            dataRecords.AddRange( ... );
    
            context.ChangeTracker.DetectChanges();
            context.SaveChanges();
        }
    }
