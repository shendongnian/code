    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.ChangeTracking;
    using System.Linq;
    using System.Reflection;
    		public override EntityEntry<TEntity> Update<TEntity>(TEntity entity) where TEntity : class
		{
			if (entity == null)
			{
				throw new System.ArgumentNullException(nameof(entity));
			}
			
			var type = entity.GetType();
			var et = this.Model.FindEntityType(type);
			var key = et.FindPrimaryKey();
			var keyNames = key.Properties.Select(s => s.Name).ToArray();
			var keyNamesLength = keyNames.Length;
			var keys = new object[keyNamesLength];
			for(var x = 0; x < keyNamesLength; x++)
			{
				var keyProperty = type.GetProperty(keyNames[x], BindingFlags.Public | BindingFlags.Instance);
			    keys[x] = keyProperty.GetValue(entity);
			}
			var originalEntity = Find(type, keys);
			if (Entry(originalEntity).State == EntityState.Modified)
			{
				return base.Update(entity);
			}
			Entry(originalEntity).CurrentValues.SetValues(entity);
			return Entry((TEntity)originalEntity);
		}
  
