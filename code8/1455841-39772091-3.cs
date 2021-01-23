      modelBuilder.Entity<UserContact>()
            .HasOne(pt => pt.Contact)
            .WithMany(p => p.UserContacts)
            .HasForeignKey(pt => pt.ContactId);
    
        modelBuilder.Entity<UserContact>()
            .HasOne(pt => pt.User)
            .WithMany(t => t.UserContacts)
            .HasForeignKey(pt => pt.UserId);
