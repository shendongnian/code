    public override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        // Treat every float as SQL FloatType(53:
        modelBuilder.Properties<float>
            .Configure(floatType => floatType.HasColumnType("float(53)");
        
        base:OnModelCreating(modelBuilder);
    }
