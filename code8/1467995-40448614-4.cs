    static IEnumerable<Action<ISession, T>> GetRefBindActions<T>(ISessionFactory sessionFactory)
    {
    	var classMeta = sessionFactory.GetClassMetadata(typeof(T));
    	var propertyNames = classMeta.PropertyNames;
    	var propertyTypes = classMeta.PropertyTypes;
    	for (int i = 0; i < propertyTypes.Length; i++)
    	{
    		var propertyType = propertyTypes[i];
    		if (propertyType.IsAssociationType && !propertyType.IsCollectionType)
    		{
    			var propertyName = propertyNames[i];
    			var propertyClass = propertyType.ReturnedClass;
    			var propertyClassMeta = sessionFactory.GetClassMetadata(propertyClass);
    			yield return (session, target) =>
    			{
    				var oldValue = classMeta.GetPropertyValue(target, propertyName, EntityMode.Poco);
    				var id = propertyClassMeta.GetIdentifier(oldValue, EntityMode.Poco);
    				var newValue = session.Get(propertyClass, id);
    				classMeta.SetPropertyValue(target, propertyName, newValue, EntityMode.Poco);
    			};
    		}
    	}
    }
