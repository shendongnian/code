    public AgentOrderMap()
    {
        ToTable("AgentOrder");
        HasKey(m => m.Id);
        Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        Property(m => m.Status);
    }
    
