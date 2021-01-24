    var fooContext = new FooContext(); //the context to check
    var dbSets = fooContext.GetType().GetProperties()
                                        .Where(p => p.PropertyType.IsGenericType
		                                && p.PropertyType.GetGenericTypeDefinition()
		                                == typeof(DbSet<>)).ToArray(); //List Dbset<T>
    var fooA = "fooA"; //the table to search
	var dbSetProp = dbSets.SingleOrDefault(x=> x.PropertyType.GetGenericArguments()[0].Name == fooA);
    if(dbSetProp != null) {
        //fooContext has fooA table
        var dbSet = fooContex.Set(dbSetProp.PropertyType.GetGenericArguments()[0]); // or via dbSetProp.GetValue(fooContext) as DbSet
        dbSet.Add(fooARecord);
    }
