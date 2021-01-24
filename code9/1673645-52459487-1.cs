    class AuditUpdateEntry : DelegatingEntry
    {
    	public AuditUpdateEntry(IUpdateEntry source) : base(source) { }
    	public override EntityState EntityState => EntityState.Modified;
    	public override bool IsModified(IProperty property)
    	{
    		if (property.Name == nameof(IAuditable.ModifiedBy)) return true;
    		return false;
    	}
    	public override bool IsStoreGenerated(IProperty property)
    		=> property.ValueGenerated.ForUpdate()
    			&& (property.AfterSaveBehavior == PropertySaveBehavior.Ignore
    				|| !IsModified(property));
    }
