	foreach (var entiry in changedEntries)
	{
		var entity = entiry.Entity;
		var entityType = entity.GetType();
		if (entity.State == EntityState.Modified)
		{                  
			var properties = entityType.GetProperties();
			var props = new List<object>();
			foreach (var prop in properties)
			{
				if(entityType.GetProperty(prop.Name) == null)
					continue;
				var pp = entityType.GetProperty(prop.Name);
				if(pp.GetValue(entity) == null)
					continue;
				var p = entity.Property(prop.Name);
				if (p.IsModified)
					props.Add(new { f = prop.Name, o = p.OriginalValue, c = p.CurrentValue });
			}
		}
	}
