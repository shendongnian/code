    // equivalent of modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
    modelBuilder.EntityTypes()
                .Configure(et => et.Relational().TableName = et.DisplayName());
    
    // Put the table name on the primary key
    modelBuilder.Properties()
                .Where(x => x.Name == "Id")
                .Configure(p => p.Relational().ColumnName = p.DeclaringEntityType.Name + "Id");
        
    // Mark timestamp columns as concurrency tokens
    modelBuilder.Properties()
                .Where(x => x.Name == "Timestamp")
                .Configure(p => p.IsConcurrencyToken = true);
