     public AgentOrderMap()
    {
        ToTable("AgentOrder");
        HasKey(m => m.Id);
        Property(m => m.Status);
    }
