    using Microsoft.EntityFrameworkCore.Metadata.Internal;
    public static void AddEntities<T>(List<T> entities, DbContext db) where T : class
    {
    	using (db)
    	{
    		var set = db.Set<T>();
    
    		var entityType = db.Model.FindEntityType(typeof(T));
    		var primaryKey = entityType.FindPrimaryKey();
    		var keyValues = new object[primaryKey.Properties.Count];
    
    		foreach (T e in entities)
    		{
    			for (int i = 0; i < keyValues.Length; i++)
    				keyValues[i] = primaryKey.Properties[i].GetGetter().GetClrValue(e);
    
    			var obj = set.Find(keyValues);
    
    			if (obj == null)
    			{
    				set.Add(e);
    			}
    			else
    			{
    				db.Entry(obj).CurrentValues.SetValues(e);
    			}
    		}
    		db.SaveChanges();
    	}
    }
