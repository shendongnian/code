    class DelegatingEntry : IUpdateEntry
    {
    	public DelegatingEntry(IUpdateEntry source) { Source = source; }
    	public IUpdateEntry Source { get; }
    	public virtual IEntityType EntityType => Source.EntityType;
    	public virtual EntityState EntityState => Source.EntityState;
    	public virtual IUpdateEntry SharedIdentityEntry => Source.SharedIdentityEntry;
    	public virtual object GetCurrentValue(IPropertyBase propertyBase) => Source.GetCurrentValue(propertyBase);
    	public virtual TProperty GetCurrentValue<TProperty>(IPropertyBase propertyBase) => Source.GetCurrentValue<TProperty>(propertyBase);
    	public virtual object GetOriginalValue(IPropertyBase propertyBase) => Source.GetOriginalValue(propertyBase);
    	public virtual TProperty GetOriginalValue<TProperty>(IProperty property) => Source.GetOriginalValue<TProperty>(property);
    	public virtual bool HasTemporaryValue(IProperty property) => Source.HasTemporaryValue(property);
    	public virtual bool IsModified(IProperty property) => Source.IsModified(property);
    	public virtual bool IsStoreGenerated(IProperty property) => Source.IsStoreGenerated(property);
    	public virtual void SetCurrentValue(IPropertyBase propertyBase, object value) => Source.SetCurrentValue(propertyBase, value);
    	public virtual EntityEntry ToEntityEntry() => Source.ToEntityEntry();
    }
