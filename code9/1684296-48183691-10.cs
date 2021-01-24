    protected virtual OnModelCreating(DbModelBuilder modelBuilder)
    {
        // From table Accounts, give property Email a unique index annotation:
        const string indexName = "indexEmails"
        var indexAttribute  = new IndexAttribute(indexName, 0) {IsUnique = true};
        var indexAnnotation = new IndexAnnotation(indexAttribute);
        propertyEmail = modelBuilder.Entity<Account>()
           .Property(account => account.Email)
           .HasColumnAnnotation(IndexAnnotation.AnnotationName, indexAnnotation);
         ...
    }
