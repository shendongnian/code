    // Entities
    modelBuilder.Entity<ApprovalGroup>()
       .ToTable("ApprovalGroup")
       .HasKey(t => t.Id);
    modelBuilder.Entity<UserDetails>()
       .ToTable("UserDetails")
       .HasKey(t => t.Id);
    
    // Relationships
    modelBuilder.Entity<ApprovalGroup>()
       .HasRequired(t => t.Approver)
       .WithMany(t => t.ApprovalGroups);
    modelBuilder.Entity<ApprovalGroup>()
       .HasMany(t => t.Members)
       .WithOptional(t => t.ApprovalGroup) // or whatever the name of the navigation property is (it's missing in the posted code)
       .WillCascadeOnDelete(false);
