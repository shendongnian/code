    modelBuilder.Entity<Tags>().ToTable("Tags")
            .HasKey(x => x.TagId);
    modelBuilder.Entity<Tags>()
            .HasOne(x => x.TagUseCount)
            .WithOne(y => y.Tags)
            .HasForeignKey(z => z.TagId)
    modelBuilder.Entity<TagUseCount>().ToTable("TagUseCount")
            .HasKey(x => x.TagId);
    
