    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.ChangeTracking;
    using Microsoft.EntityFrameworkCore.Metadata;
    using Microsoft.EntityFrameworkCore.Metadata.Internal;
    using Microsoft.EntityFrameworkCore.Update;
    using Microsoft.EntityFrameworkCore.Update.Internal;
    
    
    namespace Auditable
    {
    	public interface IAuditable
    	{
    		string ModifiedBy { get; set; }
    	}
    
    	public static class AuditableExtensions
    	{
    		public static DbContextOptionsBuilder AddAudit(this DbContextOptionsBuilder optionsBuilder)
    		{
    			optionsBuilder.ReplaceService<ICommandBatchPreparer, Internal.AuditableCommandBatchPreparer>();
    			return optionsBuilder;
    		}
    	}
    }
    
    namespace Auditable.Internal
    {
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
    
    	class AuditDeleteEntry : DelegatingEntry
    	{
    		public AuditDeleteEntry(IUpdateEntry source) : base(source) { }
    		Dictionary<IPropertyBase, object> updatedValues;
    		public override object GetCurrentValue(IPropertyBase propertyBase)
    		{
    			if (updatedValues != null && updatedValues.TryGetValue(propertyBase, out var value))
    				return value;
    			return base.GetCurrentValue(propertyBase);
    		}
    		public override object GetOriginalValue(IPropertyBase propertyBase)
    		{
    			if (updatedValues != null && updatedValues.TryGetValue(propertyBase, out var value))
    				return value;
    			return base.GetOriginalValue(propertyBase);
    		}
    		public override void SetCurrentValue(IPropertyBase propertyBase, object value)
    		{
    			if (updatedValues == null) updatedValues = new Dictionary<IPropertyBase, object>();
    			updatedValues[propertyBase] = value;
    		}
    	}
    
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
    }
