    class AuditableCommandBatchPreparer : CommandBatchPreparer
    {
    	public AuditableCommandBatchPreparer(CommandBatchPreparerDependencies dependencies) : base(dependencies) { }
    
    	public override IEnumerable<ModificationCommandBatch> BatchCommands(IReadOnlyList<IUpdateEntry> entries)
    	{
    		List<IUpdateEntry> auditEntries = null;
    		List<AuditUpdateEntry> auditUpdateEntries = null;
    		for (int i = 0; i < entries.Count; i++)
    		{
    			var entry = entries[i];
    			if (entry.EntityState == EntityState.Deleted && typeof(IAuditable).IsAssignableFrom(entry.EntityType.ClrType))
    			{
    				if (auditEntries == null)
    				{
    					auditEntries = entries.Take(i).ToList();
    					auditUpdateEntries = new List<AuditUpdateEntry>();
    				}
    				var deleteEntry = new AuditDeleteEntry(entry);
    				var updateEntry = new AuditUpdateEntry(deleteEntry);
    				auditEntries.Add(deleteEntry);
    				auditUpdateEntries.Add(updateEntry);
    			}
    			else
    			{
    				auditEntries?.Add(entry);
    			}
    		}
    		return auditEntries != null ?
    			base.BatchCommands(auditUpdateEntries).Concat(base.BatchCommands(auditEntries)) :
    			base.BatchCommands(entries);
    	}
    }
