    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.ChangeTracking;
    using System.Linq;
    	public override EntityEntry<TEntity> Update<TEntity>(TEntity entity) where TEntity : class
		{
			if (entity == null)
			{
				throw new System.ArgumentNullException(nameof(entity));
			}
			
			var type = entity.GetType();
			var et = this.Model.FindEntityType(type);
			var key = et.FindPrimaryKey();
			
			var keys = new object[key.Properties.Count];
			var x = 0;
			foreach(var keyName in key.Properties)
			{
				var keyProperty = type.GetProperty(keyName.Name, BindingFlags.Public | BindingFlags.Instance);
			    keys[x++] = keyProperty.GetValue(entity);
			}
			var originalEntity = Find(type, keys);
			if (Entry(originalEntity).State == EntityState.Modified)
			{
				return base.Update(entity);
			}
			Entry(originalEntity).CurrentValues.SetValues(entity);
			return Entry((TEntity)originalEntity);
		}
  
