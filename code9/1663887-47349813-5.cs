    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // a Project has zero or more Tools via property RequiredTools and table TableName:
        var entityProject = modelBuilder.Entity<Project>();
        entityProject.ToTable(... /* table name */);
        // a project has zero or more tools via property RequiredTools
        // every tool belongs to one required Project 
        // using foreign key ProjectId
        entityproject.HasMany(project => project.RequiredTools)
            .WithRequired(tool => tool.Project)
            .HasFreignKey(tool => tool.ProjectId);
    }
