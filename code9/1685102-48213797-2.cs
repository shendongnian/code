    builder.Entity<OrgLevelOrgLevels>()
    	.Property<int>("ParentOrgLevelId");
    
    builder.Entity<OrgLevelOrgLevels>()
    	.Property<int>("ChildOrgLevelId");
    
    builder.Entity<OrgLevelOrgLevels>()
    	 .HasKey("ParentOrgLevelId", "ChildOrgLevelId");
    
    builder.Entity<OrgLevelOrgLevels>().HasOne(olol => olol.ChildOrgLevel)
    	.WithMany(col => col.OrgLevelOrgLevelsAsChild)
    	.OnDelete(DeleteBehavior.Restrict);
    
    builder.Entity<OrgLevelOrgLevels>().HasOne(olol => olol.ParentOrgLevel)
    	.WithMany(pol => pol.OrgLevelOrgLevelsAsParent);
