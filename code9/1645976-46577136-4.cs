    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        // Configure ParentModelID as PK for ChildModel
        modelBuilder.Entity<ChildModel>()
            .HasKey(e => e.ParentModelID);
            
        // Configure ParentModelID as FK for ChildModel
        modelBuilder.Entity<ParentModel>()
                    .HasOptional(s => s.childModel) 
                    .WithRequired(ad => ad.ParentModelID); 
    
    }
