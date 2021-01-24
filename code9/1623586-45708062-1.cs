    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {   
        //set default value for your custom columns
        modelBuilder.Entity<Tag>()
            .Property(p => p.Status)
            .HasColumnName("Status")
            .HasColumnAnnotation("DefaultValue","false");
        modelBuilder.Conventions.Add(
            new AttributeToColumnAnnotationConvention<TableColumnAttribute, string>(
                "ServiceTableColumn", (property, attributes) => attributes.Single().ColumnType.ToString()));
    }
